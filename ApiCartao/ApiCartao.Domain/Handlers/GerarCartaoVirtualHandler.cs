using ApiCartao.Domain.Commands.Inputs;
using ApiCartao.Domain.Commands.Outputs;
using ApiCartao.Domain.Entities;
using ApiCartao.Domain.Repositories;
using System;

namespace ApiCartao.Domain.Handlers
{
    public class GerarCartaoVirtualHandler
    {
        private readonly ICartaoVirtualRepository _repository;

        public GerarCartaoVirtualHandler(ICartaoVirtualRepository repository)
        {
            _repository = repository;
        }

        public CommandResult Handle(GerarCartaoVirtualCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new CommandResult(false, "Email Inválido", command.Notifications);

            // Gerar número de cartão aleatório
            var numeroCartao = string.Empty;

            for (int i = 0; i < 4; i++)
            {
                var random = new Random();
                var blocoCartao = $"{random.Next(1000, 9999)}";
                numeroCartao = $"{numeroCartao + blocoCartao}";
            }

            // Criar entidade e salvar no banco
            var cartaoVirtual = new CartaoVirtual(command.Email, numeroCartao, DateTime.Now);

            try
            {
                _repository.AdicionarCartaoVirtual(cartaoVirtual);
            }
            catch (Exception e)
            {
                return new CommandResult(false, "Erro ao salvar os dados", e.Message);
            }

            // Criar command result e retornar
            var commandResult = new CommandResult(true, "Requisição Realizada com Sucesso", new { command.Email, numeroCartao });

            return commandResult;
        }
    }
}

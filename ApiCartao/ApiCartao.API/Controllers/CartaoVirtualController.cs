using ApiCartao.Domain.Commands.Inputs;
using ApiCartao.Domain.Entities;
using ApiCartao.Domain.Handlers;
using ApiCartao.Domain.Repositories;
using ApiCartao.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ApiCartao.API.Controllers
{
    [Route("v1/cartoes")]
    public class CartaoVirtualController
    {
        private readonly ICartaoVirtualRepository _repository;

        public CartaoVirtualController(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetService<ICartaoVirtualRepository>();
        }

        [HttpGet]
        [Route("{email}")]
        public IEnumerable<CartaoVirtual> Get(string email)
        {
            var cartoes = _repository.ListarCartaoVirtual(email);

            return cartoes;
        }

        [HttpPost]
        [Route("")]
        public ICommandResult Post([FromBody] GerarCartaoVirtualCommand command)
        {
            var handler = new GerarCartaoVirtualHandler(_repository);

            return handler.Handle(command);
        }
    }
}

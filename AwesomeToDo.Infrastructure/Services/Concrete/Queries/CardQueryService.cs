﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Dto.Card;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Queries
{
    internal class CardQueryService : ICardQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CardQueryService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IList<CardDto>> Get(Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            return mapper.Map<IList<CardDto>>(user.Cards);
        }

        public async Task<CardDto> Get(Guid userId, Guid id)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(s => s.Id == id, ErrorCode.UserCardNotExist);
            return mapper.Map<CardDto>(card);
        }
    }
}

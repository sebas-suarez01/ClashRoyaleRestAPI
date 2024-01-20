﻿using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Domain.DomainEvents;

public record ChallengeCreatedDomainEvent(ChallengeId ChallengeId) : DomainEvent
{
}
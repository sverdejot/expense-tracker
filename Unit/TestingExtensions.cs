﻿using Bogus;

namespace Unit;

public static class TestingExtensions
{
    public static Faker<T> UsePrivateConstructor<T>(this Faker<T> faker)
        where T : class =>
        faker.CustomInstantiator(f =>
            Activator.CreateInstance(typeof(T), nonPublic: true) as T)
         as Faker<T>;
}

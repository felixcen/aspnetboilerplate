﻿using System;
using Xunit;

namespace Abp.Tests.Domain.Values
{
    public class ValueObject_Simple_Tests
    {
        [Fact]
        public void Value_Objects_Should_Be_Same_If_Contains_Same_Data()
        {
            var guid = Guid.NewGuid();

            var address1 = new Address(guid, "Baris Manco Street", 42);
            var address2 = new Address(guid, "Baris Manco Street", 42);

            Assert.Equal(address1, address2);
            Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
            Assert.True(address1 == address2);
        }

        [Fact]
        public void Value_Objects_Should_Not_Be_Same_If_Contains_Different_Data()
        {
            Assert.NotEqual(
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Street", 42),
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5A0"), "Baris Manco Street", 42)
            );

            Assert.NotEqual(
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Streettt", 42),
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Street", 42)
            );

            Assert.NotEqual(
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Street", 42),
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Street", 45)
            );
        }

        [Fact]
        public void Value_Objects_Should_Not_Be_Same_If_One_Of_Them_Is_Null()
        {
            Assert.NotEqual(
                new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Street", 42),
                null
            );

            Assert.True(new Address(new Guid("21C67A65-ED5A-4512-AA29-66308FAAB5AF"), "Baris Manco Street", 42) != null);
        }
    }
}

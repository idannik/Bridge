﻿using System;
using System.Runtime.CompilerServices;
using Bridge.Test;
using Bridge.ClientTest;

namespace Bridge.ClientTest.SimpleTypes
{
    [Category(Constants.MODULE_UINT32)]
    [TestFixture(TestNameFormat = "UInt32 - {0}")]
    public class UInt32Tests
    {
        [Test]
        public void TypePropertiesAreCorrect()
        {
            Assert.True((object)(int)0 is uint);
            Assert.False((object)0.5 is uint);
            Assert.False((object)-1 is uint);
            Assert.False((object)4294967296 is uint);
            Assert.AreEqual("Bridge.UInt32", typeof(uint).GetClassName());
            object i = (uint)0;
            Assert.True(i is uint);
            Assert.True(i is IComparable<uint>);
            Assert.True(i is IEquatable<uint>);
            Assert.True(i is IFormattable);
        }

        [Test]
        public void CastsWork()
        {
            long i1 = -1, i2 = 0, i3 = 234, i4 = 4294967295, i5 = 4294967296;
            long? ni1 = -1, ni2 = 0, ni3 = 234, ni4 = 4294967295, ni5 = 4294967296, ni6 = null;

            unchecked
            {
                Assert.AreStrictEqual(4294967295, (uint)i1, "-1 unchecked");
                Assert.AreStrictEqual(0, (uint)i2, "0 unchecked");
                Assert.AreStrictEqual(234, (uint)i3, "234 unchecked");
                Assert.AreStrictEqual(4294967295, (uint)i4, "4294967295 unchecked");
                Assert.AreStrictEqual(0, (uint)i5, "4294967296 unchecked");

                Assert.AreStrictEqual(4294967295, (uint?)ni1, "nullable -1 unchecked");
                Assert.AreStrictEqual(0, (uint?)ni2, "nullable 0 unchecked");
                Assert.AreStrictEqual(234, (uint?)ni3, "nullable 234 unchecked");
                Assert.AreStrictEqual(4294967295, (uint?)ni4, "nullable 4294967295 unchecked");
                Assert.AreStrictEqual(0, (uint?)ni5, "nullable 4294967296 unchecked");
                Assert.AreStrictEqual(null, (uint?)ni6, "null unchecked");
            }

            checked
            {
                Assert.Throws(() => { var b = (uint)i1; }, err => err is OverflowException);
                Assert.AreStrictEqual(0, (uint)i2, "0 checked");
                Assert.AreStrictEqual(234, (uint)i3, "234 checked");
                Assert.AreStrictEqual(4294967295, (uint)i4, "4294967295 checked");
                Assert.Throws(() => { var b = (uint)i5; }, err => err is OverflowException);

                Assert.Throws(() => { var b = (uint?)ni1; }, err => err is OverflowException);
                Assert.AreStrictEqual(0, (uint?)ni2, "nullable 0 checked");
                Assert.AreStrictEqual(234, (uint?)ni3, "nullable 234 checked");
                Assert.AreStrictEqual(4294967295, (uint?)ni4, "nullable 4294967295 checked");
                Assert.Throws(() => { var b = (uint?)ni5; }, err => err is OverflowException);
                Assert.AreStrictEqual(null, (uint?)ni6, "null checked");
            }
        }

        private T GetDefaultValue<T>()
        {
            return default(T);
        }

        [Test]
        public void DefaultValueIs0()
        {
            Assert.AreStrictEqual(0, GetDefaultValue<uint>());
        }

        [Test]
        public void DefaultConstructorReturnsZero()
        {
            Assert.AreStrictEqual(0, new uint());
        }

        [IgnoreTest(Until = Constants.IGNORE_DATE)]
        [Test]
        public void CreatingInstanceReturnsZero()
        {
            Assert.AreStrictEqual(0, Activator.CreateInstance<uint>());
        }

        [Test]
        public void ConstantsWork()
        {
            Assert.AreEqual(0, uint.MinValue);
            Assert.AreEqual(4294967295U, uint.MaxValue);
        }

        [Test]
        public void FormatWorks()
        {
            Assert.AreEqual("123", ((uint)0x123).Format("x"));
        }

        [Test]
        public void IFormattableToStringWorks()
        {
            Assert.AreEqual("123", ((uint)0x123).ToString("x"));
        }

        [Test]
        public void TryParseWorks()
        {
            uint numberResult;
            bool result = uint.TryParse("23445", out numberResult);
            Assert.True(result);
            Assert.AreEqual(23445, numberResult);

            result = uint.TryParse("", out numberResult);
            Assert.False(result);
            Assert.AreEqual(0, numberResult);

            result = uint.TryParse(null, out numberResult);
            Assert.False(result);
            Assert.AreEqual(0, numberResult);

            result = uint.TryParse("notanumber", out numberResult);
            Assert.False(result);
            Assert.AreEqual(0, numberResult);

            result = uint.TryParse("-1", out numberResult);
            Assert.False(result);
            Assert.AreEqual(-1, numberResult);

            result = uint.TryParse("2.5", out numberResult);
            Assert.False(result);
            Assert.AreEqual(0, numberResult);
        }

        [Test]
        public void ParseWorks()
        {
            Assert.AreEqual(23445, uint.Parse("23445"));
            Assert.Throws(() => uint.Parse(""));
            Assert.Throws(() => uint.Parse(null));
            Assert.Throws(() => uint.Parse("notanumber"));
            Assert.Throws(() => uint.Parse("4294967296"));
            Assert.Throws(() => uint.Parse("-1"));
            Assert.Throws(() => uint.Parse("2.5"));
        }

        [Test]
        public void ToStringWithoutRadixWorks()
        {
            Assert.AreEqual("123", ((uint)123).ToString());
        }

        [Test]
        public void ToStringWithRadixWorks()
        {
            Assert.AreEqual("123", ((uint)123).ToString(10));
            Assert.AreEqual("123", ((uint)0x123).ToString(16));
        }

        [Test]
        public void GetHashCodeWorks()
        {
            Assert.AreEqual(((uint)0).GetHashCode(), ((uint)0).GetHashCode());
            Assert.AreEqual(((uint)1).GetHashCode(), ((uint)1).GetHashCode());
            Assert.AreNotEqual(((uint)1).GetHashCode(), ((uint)0).GetHashCode());
        }

        [Test]
        public void EqualsWorks()
        {
            Assert.True(((uint)0).Equals((object)(uint)0));
            Assert.False(((uint)1).Equals((object)(uint)0));
            Assert.False(((uint)0).Equals((object)(uint)1));
            Assert.True(((uint)1).Equals((object)(uint)1));
        }

        [Test]
        public void IEquatableEqualsWorks()
        {
            Assert.True(((uint)0).Equals((uint)0));
            Assert.False(((uint)1).Equals((uint)0));
            Assert.False(((uint)0).Equals((uint)1));
            Assert.True(((uint)1).Equals((uint)1));

            Assert.True(((IEquatable<uint>)((uint)0)).Equals((uint)0));
            Assert.False(((IEquatable<uint>)((uint)1)).Equals((uint)0));
            Assert.False(((IEquatable<uint>)((uint)0)).Equals((uint)1));
            Assert.True(((IEquatable<uint>)((uint)1)).Equals((uint)1));
        }

        [Test]
        public void CompareToWorks()
        {
            Assert.True(((uint)0).CompareTo((uint)0) == 0);
            Assert.True(((uint)1).CompareTo((uint)0) > 0);
            Assert.True(((uint)0).CompareTo((uint)1) < 0);
        }

        [Test]
        public void IComparableCompareToWorks()
        {
            Assert.True(((IComparable<uint>)((uint)0)).CompareTo((uint)0) == 0);
            Assert.True(((IComparable<uint>)((uint)1)).CompareTo((uint)0) > 0);
            Assert.True(((IComparable<uint>)((uint)0)).CompareTo((uint)1) < 0);
        }
    }
}

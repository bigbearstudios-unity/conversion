using System;
using NUnit.Framework;
using System.Collections.Generic;
using BBUnity.Conversion;
using BBUnity.TestSupport;

public class NumberToTests {

    // ================================================================
    // RomanNumeral — standard denominator symbols
    // ================================================================

    [Test]
    public void RomanNumeral_SingleDenominators_ReturnCorrectSymbol() {
        UnityAssert.AreEqual(new Dictionary<int, string> {
            { 1,    "I" },
            { 5,    "V" },
            { 10,   "X" },
            { 50,   "L" },
            { 100,  "C" },
            { 500,  "D" },
            { 1000, "M" },
        }, NumberTo.RomanNumeral);
    }

    // ================================================================
    // RomanNumeral — additive notation
    // ================================================================

    [Test]
    public void RomanNumeral_AdditiveNotation_ReturnCorrectString() {
        UnityAssert.AreEqual(new Dictionary<int, string> {
            { 2,  "II"    },
            { 3,  "III"   },
            { 6,  "VI"    },
            { 7,  "VII"   },
            { 8,  "VIII"  },
            { 15, "XV"    },
            { 28, "XXVIII"},
        }, NumberTo.RomanNumeral);
    }

    // ================================================================
    // RomanNumeral — subtractive notation
    // ================================================================

    [Test]
    public void RomanNumeral_SubtractiveNotation_ReturnCorrectString() {
        UnityAssert.AreEqual(new Dictionary<int, string> {
            { 4,   "IV"  },
            { 9,   "IX"  },
            { 14,  "XIV" },
            { 19,  "XIX" },
            { 40,  "XL"  },
            { 90,  "XC"  },
            { 400, "CD"  },
            { 900, "CM"  },
        }, NumberTo.RomanNumeral);
    }

    // ================================================================
    // RomanNumeral — complex / boundary values
    // ================================================================

    [Test]
    public void RomanNumeral_ComplexValues_ReturnCorrectString() {
        UnityAssert.AreEqual(new Dictionary<int, string> {
            { 1,    "I"          },
            { 1999, "MCMXCIX"   },
            { 2024, "MMXXIV"    },
            { 3999, "MMMCMXCIX" },
        }, NumberTo.RomanNumeral);
    }

    // ================================================================
    // RomanNumeral — input validation
    // ================================================================

    [Test]
    public void RomanNumeral_Zero_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.RomanNumeral(0));
    }

    [Test]
    public void RomanNumeral_NegativeNumber_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.RomanNumeral(-1));
    }

    [Test]
    public void RomanNumeral_AboveMaximum_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.RomanNumeral(4000));
    }

    // ================================================================
    // Hex — standard values
    // ================================================================

    [Test]
    public void Hex_CommonValues_ReturnCorrectHexString() {
        UnityAssert.AreEqual(new Dictionary<int, string> {
            { 0,   "0"   },
            { 10,  "A"   },
            { 15,  "F"   },
            { 16,  "10"  },
            { 255, "FF"  },
            { 256, "100" },
        }, NumberTo.Hex);
    }

    // ================================================================
    // Hex — input validation
    // ================================================================

    [Test]
    public void Hex_NegativeNumber_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.Hex(-1));
    }

    // ================================================================
    // RetroScore — default places (10)
    // ================================================================

    [Test]
    public void RetroScore_DefaultPlaces_ReturnsCorrectScore() {
        UnityAssert.AreEqual(new Dictionary<int, string> {
            { 1,          "0000000001" },
            { 10,         "0000000010" },
            { 100,        "0000000100" },
            { 1000,       "0000001000" },
            { 10000,      "0000010000" },
            { 100000,     "0000100000" },
            { 1000000,    "0001000000" },
            { 10000000,   "0010000000" },
            { 100000000,  "0100000000" },
            { 1000000000, "1000000000" },
        }, (int value) => NumberTo.RetroScore(value));
    }

    // ================================================================
    // RetroScore — custom places
    // ================================================================

    [Test]
    public void RetroScore_CustomPlaces_PrependCorrectNumberOfZeros() {
        Assert.AreEqual("000001",     NumberTo.RetroScore(1, 5));
        Assert.AreEqual("000100",     NumberTo.RetroScore(100, 3));
        Assert.AreEqual("0100000000", NumberTo.RetroScore(100000000, 2));
    }

    [Test]
    public void RetroScore_PlacesExceedAvailableCapacity_CapsAtAvailableSpace() {
        // score=1 has 1 digit; max padding = 9; requesting 20 should cap at 9
        Assert.AreEqual("0000000001", NumberTo.RetroScore(1, 20));
    }

    // ================================================================
    // RetroScore — input validation
    // ================================================================

    [Test]
    public void RetroScore_NegativeScore_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.RetroScore(-1));
    }

    [Test]
    public void RetroScore_ZeroPlaces_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.RetroScore(1, 0));
    }

    [Test]
    public void RetroScore_NegativePlaces_ThrowsArgumentOutOfRangeException() {
        Assert.Throws<ArgumentOutOfRangeException>(() => NumberTo.RetroScore(1, -1));
    }
}

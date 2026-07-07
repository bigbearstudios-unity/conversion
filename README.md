# BBUnity Conversion

## NumberTo

### RomanNumeral

Converts an integer to a standard Roman numeral string using subtractive notation.
Valid input range is **1–3999**. Throws `ArgumentOutOfRangeException` outside that range.

```csharp
using BBUnity.Conversion;

NumberTo.RomanNumeral(1);    // I
NumberTo.RomanNumeral(4);    // IV
NumberTo.RomanNumeral(9);    // IX
NumberTo.RomanNumeral(28);   // XXVIII
NumberTo.RomanNumeral(1999); // MCMXCIX
NumberTo.RomanNumeral(3999); // MMMCMXCIX
```

### Hex

Converts a non-negative integer to its uppercase hexadecimal string.
Throws `ArgumentOutOfRangeException` for negative values.

```csharp
using BBUnity.Conversion;

NumberTo.Hex(0);   // 0
NumberTo.Hex(10);  // A
NumberTo.Hex(255); // FF
NumberTo.Hex(256); // 100
```

### RetroScore

Converts a non-negative integer to a zero-padded retro score string.
The optional `places` parameter controls how many leading zeroes are prepended (default 10).
When the score fills all available digits the padding is automatically reduced to fit.
Throws `ArgumentOutOfRangeException` for negative scores or a `places` value below 1.

```csharp
using BBUnity.Conversion;

NumberTo.RetroScore(1);           // 0000000001
NumberTo.RetroScore(100);         // 0000000100
NumberTo.RetroScore(1000000000);  // 1000000000
NumberTo.RetroScore(1, 5);        // 000001
NumberTo.RetroScore(100, 3);      // 000100
```

## Thread Safety

`NumberTo.RetroScore()` uses a shared static `StringBuilder` internally. Concurrent calls from multiple threads will corrupt each other's output with no warning. In standard Unity single-threaded gameplay this is not a concern, but do not call `RetroScore()` from a Job, Task, or any other thread without external locking.

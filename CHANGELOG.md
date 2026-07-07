# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.0.1] - 2024-07-15
### Added

- Added conversion for:
  - ListTo.String
  - NumberTo.RomanNumeral
  - NumberTo.RetroScore

## [0.2.1] - 2024-11-22
### Added

- Simplifed with String to string

## [1.0.0] - 2026-04-29

### Added

- Input validation on all public `NumberTo` methods with descriptive `ArgumentOutOfRangeException` messages:
  - `RomanNumeral()` — rejects values below 1 or above 3999
  - `Hex()` — rejects negative values
  - `RetroScore()` — rejects negative scores and `places` values below 1
- XML documentation summaries on all public methods in `NumberTo`
- Comprehensive test suite covering `RomanNumeral` (additive, subtractive, complex, and boundary values), `Hex` (common values), and `RetroScore` (default places, custom places, capacity capping, and all validation cases)
- Thread safety notice added to README

### Changed

- **Breaking** — `NumberTo.RomanNumeral()` now produces standard subtractive notation (`XXVIII` for 28, `IV` for 4, `IX` for 9, etc.) replacing the previous non-standard closest-denominator output
- **Breaking** — `NumberTo.RomanNumeral()`, `NumberTo.Hex()`, and `NumberTo.RetroScore()` now throw `ArgumentOutOfRangeException` for inputs that previously produced silent garbage output
- `NumberToRomanNumerals` rewritten as an iterative greedy algorithm; the previous recursive `EvaluateRomanNumeral` implementation has been removed
- `NumberToRetroScore.Builder` initialised inline (`= new StringBuilder(10)`) replacing the separate static constructor, eliminating a potential `NullReferenceException` on first call
- README corrected: fixed misspelled namespace (`BBUnity.Converstion` → `BBUnity.Conversion`), replaced non-compiling examples, and removed the `ListTo` section

### Removed

- **Breaking** — `ListTo` class and all its members removed; use `string.Join()` directly
- `ListToTests` removed alongside `ListTo`
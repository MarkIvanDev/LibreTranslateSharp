using System.Collections.Generic;

namespace LibreTranslateSharp.Models;

public record class FrontendSettingsResult(
    bool ApiKeys,
    int CharLimit,
    int FrontendTimeout,
    bool KeyRequired,
    FrontendLanguageSetting Language,
    bool Suggestions,
    IList<string> SupportedFilesFormat);

public record class FrontendLanguageSetting(
    FrontendLanguage Source,
    FrontendLanguage Target);

public record class FrontendLanguage(
    string Code,
    string Name);
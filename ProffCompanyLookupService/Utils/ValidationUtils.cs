﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace ProffCompanyLookupService.Utils
{
  public static class ValidationUtils
  {
    private static string _validationMessage;

    public static (bool isValid, string orgNr, string domain, string countryCode, string validationMessage) ValidateQueryInput(HttpRequest req)
    {
      string orgNr = req.Query["orgNr"];
      string domain = req.Query["domain"];
      string countryCode = StringValues.IsNullOrEmpty(req.Query["countryCode"]) ? "NO" : req.Query["countryCode"].ToString();
      bool isValid;

      (isValid, orgNr) = ValidateAndFormatOrgNr(orgNr);

      if (!isValid)
      {
        return (isValid, "", "", "", _validationMessage);
      }

      if (string.IsNullOrEmpty(domain))
      {
        return (false, "", "", "", "missing domain parameter");
      }

      return (isValid, orgNr, domain, countryCode, _validationMessage);
    }

    public static (bool IsValid, string FormattedValue) ValidateAndFormatOrgNr(string orgNr)
    {
      _validationMessage = "organisationNumber cannot be null or empty\n";
      if (string.IsNullOrEmpty(orgNr)) return (false, orgNr);

      string formattedOrgNr = orgNr.Replace(" ", "");

      bool isValid = formattedOrgNr.Length == 9 && formattedOrgNr.All(char.IsDigit);
      if (!isValid) _validationMessage = "organisationNumber is not correctly formatted\n";

      return (isValid, formattedOrgNr);
    }
  }
}
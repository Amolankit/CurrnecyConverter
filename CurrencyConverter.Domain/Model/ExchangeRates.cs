namespace CurrencyConverter.Domain.Model;

public class ExchangeRates
{
    public Rate Base { get; set; }
    public string Date { get; set; }
    public IEnumerable<Rate> Rates { get; set; }

    public ExchangeRates(Rate baseRate, string date, IEnumerable<Rate> rates)
    {
        Base = baseRate;
        Date = date ?? throw new ArgumentNullException(nameof(date));
        Rates = rates;
    }

    public decimal GetExchangeRate(string from, string to, decimal amount)
    {
        #region Validations
        _ = from ?? throw new ArgumentNullException(from);
        _ = to ?? throw new ArgumentNullException(to);

        if (amount < 0)
        {
            throw new InvalidOperationException("Amount value cannot be lower than 0.");
        }

        if (!Base.CurrencyType.Equals(from, StringComparison.OrdinalIgnoreCase) && !Rates.Any(x => x.CurrencyType.Equals(from, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Currency: {from} not supported.");
        }
        if (!Base.CurrencyType.Equals(to, StringComparison.OrdinalIgnoreCase) && !Rates.Any(x => x.CurrencyType.Equals(to, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Currency: {to} not supported.");
        }
        #endregion

        decimal resultAmount = 0;
        if (from.Equals(Base.CurrencyType, StringComparison.OrdinalIgnoreCase))
        {
            var currentCurrencyRate = Rates.FirstOrDefault(x => x.CurrencyType.Equals(to, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception("No exchange rate found for this currency");
            resultAmount = currentCurrencyRate.Value * amount;
        }
        else
        {
            var rateFrom =
                Rates.FirstOrDefault(x => x.CurrencyType.Equals(from, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception("No exchange rate found for this currency");
            var rateTo =
                Rates.FirstOrDefault(x => x.CurrencyType.Equals(to, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception("No exchange rate found for this currency");
            var euroExchangeRate = amount / rateFrom.Value;
            resultAmount = euroExchangeRate * rateTo.Value;
        }
        return resultAmount;
    }
}


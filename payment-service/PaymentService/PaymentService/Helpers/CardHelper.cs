namespace PaymentService.Helpers
{
    public static class CardHelper
    {
        public static bool IsValidCard(string? cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            int sum = 0;
            bool alternate = false;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(cardNumber[i]))
                    return false;

                int digit = cardNumber[i] - '0';
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }
                sum += digit;
                alternate = !alternate;
            }
            return sum % 10 == 0;
        }

        public static string Mask(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 4)
                return "****";

            return new string('*', cardNumber.Length - 4) + cardNumber.Substring(cardNumber.Length - 4);
        }
    }
}

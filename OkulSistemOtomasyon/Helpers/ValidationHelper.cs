namespace OkulSistemOtomasyon.Helpers
{
    /// <summary>
    /// Çeşitli doğrulama işlemleri için yardımcı sınıf
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// TC Kimlik No doğrulama
        /// </summary>
        public static bool TCKimlikNoDogrula(string tcNo)
        {
            if (string.IsNullOrWhiteSpace(tcNo) || tcNo.Length != 11)
                return false;

            if (!tcNo.All(char.IsDigit))
                return false;

            if (tcNo[0] == '0')
                return false;

            // TC algoritması
            int[] digits = tcNo.Select(c => int.Parse(c.ToString())).ToArray();
            
            int odd = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int even = digits[1] + digits[3] + digits[5] + digits[7];
            
            int digit10 = ((odd * 7) - even) % 10;
            if (digit10 != digits[9])
                return false;

            int sum = digits.Take(10).Sum();
            int digit11 = sum % 10;
            
            return digit11 == digits[10];
        }

        /// <summary>
        /// Email doğrulama
        /// </summary>
        public static bool EmailDogrula(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Telefon numarası doğrulama
        /// </summary>
        public static bool TelefonDogrula(string telefon)
        {
            if (string.IsNullOrWhiteSpace(telefon))
                return true; // Opsiyonel alan

            // Sadece rakam ve bazı özel karakterlere izin ver
            string temizTelefon = new string(telefon.Where(c => char.IsDigit(c)).ToArray());
            
            return temizTelefon.Length >= 10 && temizTelefon.Length <= 11;
        }
    }
}

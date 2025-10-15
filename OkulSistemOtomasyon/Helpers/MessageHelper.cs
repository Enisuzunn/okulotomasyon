using DevExpress.XtraEditors;

namespace OkulSistemOtomasyon.Helpers
{
    /// <summary>
    /// Mesaj gösterimi için yardımcı sınıf
    /// </summary>
    public static class MessageHelper
    {
        public static void BilgiMesaji(string mesaj, string baslik = "Bilgi")
        {
            XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void HataMesaji(string mesaj, string baslik = "Hata")
        {
            XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void UyariMesaji(string mesaj, string baslik = "Uyarı")
        {
            XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool OnayMesaji(string mesaj, string baslik = "Onay")
        {
            var result = XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public static void BasariMesaji(string mesaj = "İşlem başarıyla tamamlandı.")
        {
            XtraMessageBox.Show(mesaj, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void SilmeOnayMesaji(Action silmeIslemi, string mesaj = "Seçili kaydı silmek istediğinize emin misiniz?")
        {
            if (OnayMesaji(mesaj, "Silme Onayı"))
            {
                try
                {
                    silmeIslemi();
                    BasariMesaji("Kayıt başarıyla silindi.");
                }
                catch (Exception ex)
                {
                    HataMesaji($"Silme işlemi sırasında hata oluştu:\n{ex.Message}");
                }
            }
        }
    }
}

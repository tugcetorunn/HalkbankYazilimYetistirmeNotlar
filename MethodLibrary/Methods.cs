using System.Text;

namespace MethodLibrary
{
    public class Methods
    {
        #region TurkceKarakterleriIngilizceKarakterlereCeviripYenidenYazma (uzun yol)
        static string IngilizceKaraktereDonustur(string metin)
        {
            char[] strDizi = metin.ToCharArray();
            string yeniMetin = "";
            string degisenItem = "";
            foreach (var item in strDizi)
            {
                yeniMetin += item;

                if (item == 'ı' || item == 'ö' || item == 'ü' || item == 'ş' || item == 'ç' || item == 'ğ')
                {
                    yeniMetin = yeniMetin.Substring(0, yeniMetin.Length - 1); // Türkçe karakteri sileriz.

                    degisenItem = item.ToString().ToLower(); // çünkü item iterasyon elemanı old için değer atayamayız.
                    switch (degisenItem)
                    {
                        case "ı":
                            degisenItem = "i";
                            break;
                        case "ö":
                            degisenItem = "o";
                            break;
                        case "ü":
                            degisenItem = "u";
                            break;
                        case "ş":
                            degisenItem = "s";
                            break;
                        case "ç":
                            degisenItem = "c";
                            break;
                        case "ğ":
                            degisenItem = "g";
                            break;
                        default:
                            break;
                    }

                    yeniMetin += degisenItem; // Türkçe karakteri ingilizce karaktere dönüştürüp ekliyoruz.
                }
            }
            return yeniMetin;
        }
        #endregion
        #region TurkceKarakterleriIngilizceKarakterlereCeviripYenidenYazma (kısa yol 1.)
        static string IngilizceKaraktereDonusturKisa(string metin)
        {
            return metin.Replace("ı", "i").Replace("ö", "o").Replace("ü", "u").Replace("ş", "s").Replace("ç", "c").Replace("ğ", "g");
        }
        #endregion
        #region TurkceKarakterleriIngilizceKarakterlereCeviripYenidenYazma (kısa yol 2.)
        static string IngilizceKaraktereDonusturKisa2(string metin)
        {
            var turkce2Ingilizce = new Dictionary<char, char>
            {
                { 'ı', 'i' }, { 'İ', 'I' },
                { 'ö', 'o' }, { 'Ö', 'O' },
                { 'ü', 'u' }, { 'Ü', 'U' },
                { 'ş', 's' }, { 'Ş', 'S' },
                { 'ç', 'c' }, { 'Ç', 'C' },
                { 'ğ', 'g' }, { 'Ğ', 'G' }
            };

            var sb = new StringBuilder(metin.Length);

            foreach (var ch in metin)
            {
                sb.Append(turkce2Ingilizce.TryGetValue(ch, out char yeniChar) ? yeniChar : ch);
            }

            return sb.ToString();
        }
        #endregion


    }


}

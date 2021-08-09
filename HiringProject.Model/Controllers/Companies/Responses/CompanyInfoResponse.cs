namespace HiringProject.Model.Controllers.Companies.Responses
{
    public class CompanyInfoResponse
    {
        /// <summary>
        /// Şirketin kayıt numarası
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Şirketin Adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Şirketin adresi
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Şirketin telefon numarası
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Şirketin ilan yayınlama hakkı sayısı
        /// </summary>
        public int RemainPublishJobCount { get; set; } = 2;
    }
}

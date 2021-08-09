namespace HiringProject.Model.Controllers.Companies.Requests
{
    public class PostCompanyRequest
    {
        /// <summary>
        /// Adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adresi
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Telefon numarası
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// İlan yayınlama hakkı sayısı
        /// </summary>
        public int RemainPublishJobCount { get; set; } = 2;
    }
}

namespace HiringProject.Model.Controllers.Companies.Responses
{
    public class CompanyInfoResponse
    {
        /// <summary>
        /// Şirketin kayıt numarası
        /// </summary>
        /// <example>6110eeee7a242e4c09c8ba65</example>
        public string Id { get; set; }

        /// <summary>
        /// Şirketin Adı
        /// </summary>
        /// <example>Your Company Name</example>
        public string Name { get; set; }

        /// <summary>
        /// Şirketin adresi
        /// </summary>
        /// <example>Istanbul/Turkey</example>
        public string Address { get; set; }

        /// <summary>
        /// Şirketin telefon numarası
        /// </summary>
        /// <example>5324567890</example>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Şirketin ilan yayınlama hakkı sayısı
        /// </summary>
        /// <example>2</example>
        public int RemainPublishJobCount { get; set; } = 2;
    }
}

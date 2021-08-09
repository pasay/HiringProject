namespace HiringProject.Model.Controllers.Jobs.Requests
{
    public class GetAllJobRequest
    {
        /// <summary>
        /// Listelenecek ilanların bağlı olduğu şirketin kayıt numarası
        /// </summary>
        public string CompanyId { get; set; }
    }
}

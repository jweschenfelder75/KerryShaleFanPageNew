namespace de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic
{
    public interface IBusinessLogicService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DoWorkAsync(CancellationToken cancellationToken);
    }
}

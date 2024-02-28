namespace de.jweschenfelder.KSFP.Web.Interfaces.MailAndSmsServices;

public interface IMailAndSmsService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="from"></param>
	/// <param name="to"></param>
	/// <param name="subject"></param>
	/// <param name="message"></param>
	/// <returns></returns>
	public bool SendMailNotification(string from, string to, string subject, string? message);

	/// <summary>
	/// 
	/// </summary>
	/// <param name="from"></param>
	/// <param name="to"></param>
	/// <param name="subject"></param>
	/// <param name="message"></param>
	/// <returns></returns>
	public bool SendSmsNotification(string from, string to, string subject, string? message);
}

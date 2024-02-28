using System;
using System.ComponentModel.DataAnnotations;

namespace de.jweschenfelder.KSFP.Shared.Objects
{
    [Serializable]
    public class ContactDataDto
    {
		[Required(ErrorMessage = "Name is required."), DataType(DataType.Text), MaxLength(150, ErrorMessage = "Name must not be longer than 150 characters.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "EMail is required."), DataType(DataType.EmailAddress), MaxLength(200, ErrorMessage = "Email must not be longer than 200 characters.")]
		public string EMail { get; set; } = string.Empty;

		[Required(ErrorMessage = "Subject is required."), DataType(DataType.Text), MaxLength(250, ErrorMessage = "Subject must not be longer than 250 characters.")]
		public string Subject { get; set; } = string.Empty;

		[Required(ErrorMessage = "Message is required."), DataType(DataType.MultilineText), MaxLength(1000, ErrorMessage = "Message must not be longer than 1000 characters.")]
		public string Message { get; set; } = string.Empty;
    }
}

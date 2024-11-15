using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CalculatorDemo2.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ContactMeViewModel
    {
        public string  feedbackText { get; set; }
        public string FeedbackText
        {
            get => feedbackText;

            set
            {
                feedbackText = value;
                IsButtonEnabled = !string.IsNullOrEmpty(feedbackText) && feedbackText.Length > 3;
            }
        }
        public bool IsButtonEnabled { get; set; } = false;
        public string btnSubmitText { get; set; } = "ارسال";
        public bool SendingFeedback { get; set; } = false;


      
        public ICommand SendFeedbackCommand =>
            new Command(async () =>
            {
                  
                if(FeedbackText.Length > 3)
                {
                    IsButtonEnabled = false;
                    btnSubmitText = "ارسال ⏳ ";
                    SendingFeedback = true;



                    try
                    {
                        var mail = new MailMessage
                        {
                            From = new MailAddress(Utilities.Account.username),
                            Subject = " 🐸🐸  Feedback for Maui Calculator 👽👽 ",
                            Body = FeedbackText
                        };

                        mail.To.Add(Utilities.Account.username);

                        using var smtpClient = new SmtpClient(Utilities.Account.smtpServer)
                        {
                            Port= Utilities.Account.smtpPort_tls,
                            Credentials=new System.Net.NetworkCredential(Utilities.Account.username,Utilities.Account.password),
                            EnableSsl=true
                        };

                        await smtpClient.SendMailAsync(mail);
                        await Application.Current.MainPage.DisplayAlert("\u200Fموفقیت آمیز", "\u200F از بازخورد شما ممنونیم", "\u200F خروج");

                        IsButtonEnabled = true;
                        FeedbackText = "";
                        btnSubmitText = "ارسال";
                        SendingFeedback = false;


                    }
                    catch(Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("\u200Fخطا", $"\u200F ارسال پیام با مشکل مواجه شد : {ex.Message}", "‏‏\u200F خروج" );
                        IsButtonEnabled = true;
                        SendingFeedback = false;
                        btnSubmitText = "ارسال";


                    }

                    IsButtonEnabled = true;
                    FeedbackText = "";
                    btnSubmitText = "ارسال";
                    SendingFeedback = false;

                }

            });






    }
}

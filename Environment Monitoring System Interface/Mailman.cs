using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System.IO;

namespace Environment_Monitoring_System_Interface
{
    internal class MailMan
    {
        static double magnitude;
        static string symbol;
        static double minMag;
        static double maxMag;
        static string inequality;
        static string bound;
        static string name;

        public static void SendReport(string userEmail, bool language, string date, MemoryStream stream, string filePath)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("remote_monitoring_system@outlook.com", "MC_EE_Student1"),
                EnableSsl = true,
            };

            MailMessage message = new MailMessage();

            message.From = new MailAddress("remote_monitoring_system@outlook.com");
            message.To.Add(userEmail);

            if (language)
            {
                message.Subject = "REMS Informe";
                message.Body = "Adjunto el informe de lecturas diarias del " + date
                    + ". \n\n";
            }
            else
            {
                message.Subject = "REMS Report";
                message.Body = "Attached is the daily readings report for " + date
                    + ". \n\n";
            }

            message.Attachments.Add(new Attachment(stream, filePath, "text/csv"));

            try
            {
                smtpClient.Send(message);
            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
            }
        }

        public static void SendAlert(string userEmail, bool language, Sensor culprit, bool quantity, bool inequalityB)
        {
            try 
            { 
                if (quantity)
                {
                    magnitude = culprit.holdHum;
                    minMag = culprit.minHum;
                    maxMag = culprit.maxHum;
                    symbol = " %";

                    if (language)
                        name = "humedad ";
                    else
                        name = "humidity ";
                }
                else
                {
                    magnitude = culprit.holdTemp;
                    minMag = culprit.minTemp;
                    maxMag = culprit.maxTemp;

                    if (culprit.tempScale)
                        symbol = " °C";
                    else
                        symbol = " °F";

                    if (language)
                        name = "temperatura ";
                    else
                        name = "temperature ";
                }

                if (inequalityB && language)
                {
                    inequality = "superior al ";
                    bound = "su máximo del " + maxMag;
                }
                else if (!inequalityB && language)
                {
                    inequality = "inferior al ";
                    bound = "su mínimo del " + minMag;
                }
                else if (inequalityB && !language)
                {
                    inequality = "higher than ";
                    bound = "maximum of " + maxMag;
                }
                else if (!inequalityB && !language)
                {
                    inequality = "lower than ";
                    bound = "minimum of " + minMag;
                }

                SmtpClient smtpClient = new SmtpClient("smtp.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("remote_monitoring_system@outlook.com", "MC_EE_Student1"),
                    EnableSsl = true,
                };

                MailMessage message = new MailMessage();

                message.From = new MailAddress("remote_monitoring_system@outlook.com");
                message.To.Add(userEmail);

                if (language)
                {
                    message.Subject = "Incumplimiento del Umbral del Sensor- " + DateTime.Now;
                    message.Body = culprit.name + "ha detectado " +
                        "una violación de sus especificaciones. La " + name + "medida fue del "
                        + magnitude + symbol + ", " + inequality + bound + symbol + ".";
                }
                else
                {
                    message.Subject = "Sensor Threshold Breach- " + DateTime.Now;
                    message.Body = culprit.name + " has detected a violation " +
                        "of your specifications. The " + name + " measured was "
                        + magnitude + symbol + ", which is " + inequality + "your required "
                        + bound + symbol + ".";
                }
                smtpClient.Send(message);
            }     
            catch( Exception ex )
            {
                MessageBox.Show("email blank for some reason" + ex.Message);
            }
        }

        public static void SendBat(string userEmail, bool language, Sensor culprit)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("remote_monitoring_system@outlook.com", "MC_EE_Student1"),
                EnableSsl = true,
            };

            MailMessage message = new MailMessage();
            message.From = new MailAddress("remote_monitoring_system@outlook.com");
            message.To.Add(userEmail);

            if (language)
            {
                message.Subject = "Batería Crítica";
                message.Body = "La batería del " + culprit.name + " está baja (" + culprit.bat + " voltios).";
            }
            else
            {
                message.Subject = "Critical Battery";
                message.Body = culprit.name + " battery is low (" + culprit.bat + " volts).";
            }

            try
            {
                smtpClient.Send(message);
            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
            }
        }
    }
}

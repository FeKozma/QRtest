using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Net;
using QRCoder;

namespace testQr
{
    //get local IP (IPV4 address)
    public class IpV4Adress

    {
        public static string GetIp()
        {
            //get name of host
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);

            //get the Ip address
            string localIp = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Console.WriteLine("Ip address is : " + localIp);
            return localIp;
        }
    }

        /// <summary>
        /// Interaction logic for MainWindow.xa ml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {

                InitializeComponent();

                //get Ip address to use in the QR code
                string ipAddress = IpV4Adress.GetIp();

                //create instance of the generator
                QRCodeGenerator qrGenerator = new QRCodeGenerator();

                //create the data object with the IP
                // ECCLevel (Error correction level:  L(7%), M(15%), Q(25%), H(30%) : how much of the QR code can be hidden and still work)
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(ipAddress, QRCodeGenerator.ECCLevel.Q);

                //create QR code object
                QRCode qrCode = new QRCode(qrCodeData);

                //render QR code as bitmap and display
                System.Drawing.Bitmap CodeImage = qrCode.GetGraphic(20);



                IntPtr ptr = new IntPtr();
                System.Drawing.Image.GetThumbnailImageAbort IDoNo = new System.Drawing.Image.GetThumbnailImageAbort(err);
                System.Drawing.Image img = CodeImage.GetThumbnailImage(140, 140, IDoNo, ptr);
            img.Save("QRCode.jpg");
            












            }
        public bool err()
        {
            Console.WriteLine("err...");
            return false;
        }
        }
    
}

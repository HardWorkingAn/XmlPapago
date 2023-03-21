using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace Xml_PapagoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            API_ID papagoID = new API_ID(); // api id password 적혀있는 클래스 참조

            //string basePath = "C:\\Users\\user\\Desktop\\Xml_PapagoAPI\\xml\\"; // xml 위치
            string current_path = Directory.GetCurrentDirectory(); // 현재 실행파일 path를 저장
            Console.WriteLine(current_path);
            DirectoryInfo FInd_XmlDirectory = new DirectoryInfo(current_path); // 실행파일 path 디렉토리를 가져온걸 DirectoryInfo 변수에 대입
            FInd_XmlDirectory = FInd_XmlDirectory.Parent; // 상위폴더 이동
            FInd_XmlDirectory = FInd_XmlDirectory.Parent; // 상위폴더 이동
            FInd_XmlDirectory = FInd_XmlDirectory.Parent; // 상위폴더 이동
            FInd_XmlDirectory = FInd_XmlDirectory.Parent; // 상위폴더 이동
            Console.WriteLine(FInd_XmlDirectory);

            string XmlFolderName = "xml"; // xml폴더 이름

            string path = Path.Combine(FInd_XmlDirectory.ToString(), XmlFolderName); // 하위폴더 xml 폴더 붙이기
            Console.WriteLine(path);

            string FileName = "str_english" + ".xml"; // 변경할 파일 이름
            Console.WriteLine(path + FileName);
            Console.WriteLine(File.Exists(path + FileName)); // 파일의 유무 확인
           

            /*
            XmlDocument xmlDocument = new XmlDocument(); // xml 파싱을 위한 클래스
            xmlDocument.Load(path + FileName); // 위치 + 파일명

            // 태그 한국어로 변경
            XmlNodeList xnTag = xmlDocument.SelectNodes("//tag"); // string 노드 전부 List저장 들어가기
            foreach (XmlNode tagNode in xnTag)
            {
                XmlAttribute tagAttr = tagNode.Attributes["language"];
                tagAttr.Value = "한국어";
            }

            // TEXT 파파고 번역
            XmlNodeList xnList = xmlDocument.SelectNodes("//string"); // string 노드 전부 List저장 들어가기
            string query;

            foreach (XmlNode xn in xnList)
            {

                string url = "https://openapi.naver.com/v1/papago/n2mt";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("X-Naver-Client-Id", API_ID.ID); // api id
                request.Headers.Add("X-Naver-Client-Secret", API_ID.PASSWORD); // api password
                request.Method = "POST";

                //
                query = xn.Attributes["text"].Value;
                Console.WriteLine(query);
                XmlAttribute attr = xn.Attributes["text"];
                //

                byte[] byteDataParams = Encoding.UTF8.GetBytes("source=en&target=ko&text=" + query); // en  -> ko 롭 번역
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteDataParams.Length;

                Stream st = request.GetRequestStream();

                st.Write(byteDataParams, 0, byteDataParams.Length);
                st.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                string text = reader.ReadToEnd();
                JObject ret = JObject.Parse(text);


                Console.WriteLine(ret["message"]["result"]["translatedText"].ToString()); // 값 확인용 출력
                attr.Value = ret["message"]["result"]["translatedText"].ToString();   // text value값 변경

                stream.Close();
                response.Close();
                reader.Close();
                //

            }

            xmlDocument.Save(path + FileName);
            */

        }
    }
}

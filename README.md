# XmlPapago

파파고 API 사용하여 Xml 파일 파싱 후 텍스트 한글로 번역

마운트 앤 블레이드 : 배너로드 모드 XML 번역 파일 자동 한글 번역해주는 코드
xml 폴더 안 xml 파일을 넣고 API_ID.cs 생성후 

namespace Xml_PapagoAPI
{
    public class API_ID
    {
        public const string ID = "";
        public const string PASSWORD = "";
    }
}

API ID, PASSWORD 입력 후 Xml_PapagoAPI.cs 코드에 string xmlName = "";  안에 파일 이름 넣고 돌리면
Xml 파일 내용이 번역됨.
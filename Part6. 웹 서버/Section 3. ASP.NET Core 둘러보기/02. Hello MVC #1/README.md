# Section 3.2 Hello MVC #1
## MVC

MVC는 **Model, View, Controller**의 약자이다. 웹 개발에 있어서 전통적으로 사용해오던 패턴이며 사용자 인터페이스 중점의 응용 프로그램 개발에 널리 사용된다. 

- **Model : 데이터베이스와 상호 작용하거나 데이터를 조작, 저장, 검색하여 비즈니스 로직을 수행한다.**
- **View : 사용자에게 정보를 표시하고 모델의 데이터를 시각적으로 나타낸다.**
- **Controller : 사용자 입력을 처리하고 모델, 뷰 간의 상호 작용을 조정한다.**

웹 개발에 있어서 UI는 보통 HTML로 작성된다. 그에 따라 실제적인 웹 페이지를 구성하는 HTML 문서들은 Views 폴더 하위에 구성된다.


💡 **MVC 구조의 장점/단점**

프레임워크, 엔진 등을 사용하지 않고 처음부터 코딩하는 과정에서 종종 모든 로직을 하나의 페이지에 작성하곤 한다. (다이렉트 X 수업 등에서) 이는 UI를 크게 신경쓰지 않고 단순하게 화면이 보이는지를 확인하기 위한 생략이므로 그럴수 있지만, 실제 그런식으로 구현하면 안된다. 프로젝트가 진행됨에 따라 로직이 굉장히 복잡해지므로 유지보수가 어려워진다.

MVC 구조는 모델, 뷰, 컨트롤러로 분리하여 관리하는 것을 기조로 하여 유지보수에 이점이 있다. 하지만 너무 쪼개다보니 코딩에 있어 어려움이 있기도 하다. 예를 들어, 간단한 테스트조차 MVC구조에 맞춰 작성해야 하다보니 효율적인 코딩이 어려워지기도 한다. 

MVC 구조는 웹 개발 초창기부터 사용되어온 방식이다. 과거 웹은 대부분 MVC 구조를 사용하였기에 예전 프로젝트에 대한 유지보수를 하기 위해서라도 반드시 알아야하는 부분이다. 그렇지만 최근에 시작되는 여러 웹 프로젝트는 MVC를 고집하지 않는 추세이다. 이는 더 효율적인 방법들이 계속해서 등장하고 있기 때문인데, 이 처럼 웹쪽은 기술 개발 속도가 상대적으로 더 빠르기에 꾸준하게 공부해야 하는 업종이다.


## MVC 프로젝트 구현해보기

---

ASP 빈 프로젝트에서 MVC 프로젝트 폴더 구조와 같게 폴더들을 생성해 준다.

컨트롤러 폴더 내부의 파일은 새 항목 추가→MVC 컨트롤러 로 생성해주어야 한다. 이 파일은 MVC 구조를 가지는 프로젝트의 컨트롤러가 가지고 있어야 할 기본적인 형태로 작성되며 기본값으로 Home View에 대한 컨트롤러로 작성된다.

즉, `HomeController`라는 컨트롤러는 `Views→Home` 폴더에 있는 파일들에 대한 컨트롤을 담당하게 된다는 것이다. 

MVC 프로젝트로 넘어가 해당 부분을 확인해보면 다음과 같은 점을 확인할 수 있다.

```csharp
namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
		}
}
```

`HomeController` 클래스가 작성되어 있고 메소드로 `Index` 와 `Privacy`를 가지고 있는 것을 볼 수 있다.

그리고 `Views→Home` 폴더를 확인해보면 


`Index.cshtml`과 `Privacy.cshtml` 파일이 있는 것을 볼 수 있다. 각 메소드가 `Views→Home` 폴더 내부의 파일 하나씩에 대한 연결을 담당하고 있는 것이다.

이렇듯 **MVC 프로제트의 경우에는 파일 이름들을 컨벤션에 맞춰줘야 한다.**
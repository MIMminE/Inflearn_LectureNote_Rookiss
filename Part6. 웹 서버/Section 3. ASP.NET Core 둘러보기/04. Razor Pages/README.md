# Section 3.4 Razor Pages
## Razor Pages


현대적인 웹 애플리케이션을 구축하기 위한 웹 프레임워크이다. 

기존의 MVC 패턴의 방식에서 모델은 그 역할을 유지하며 존재하지만 뷰와 컨트롤러가 하나로 합쳐져서 동작한다.

**즉, 기존의 Controllers와 Views 폴더를 제거하고 Pages폴더가 생성된다)**

실습을 위해 `[ 새 항목 → Razor 페이지 ]` 를 클릭하여 Razor 항목을 생성한다. 기본값으로 `index.cshtml`이 생성되고 그 하위에 `index.cshtml.cs` 파일이 생성된 것을 볼 수 있다.

결국 Razor 페이지 하나가 **뷰**와 **컨트롤러** 역할을 하고 있는 것이다.

```csharp
public class IndexModel : PageModel
{
    //모델 바인딩 참가 암시
    [BindProperty]
    public HelloMessage HelloMsg { get; set; }

    public string Noti { get; set; }

    public void OnGet()
    {
				Message = "Hello Razor Pages"
    }

    public void OnPost()
    {
				this.Noti = "Meeage Changed";
    }
}
```

컨트롤러 부분에 위와 같이 작성한다. 

웹 페이지가 처음으로 호출될 때 Get 방식으로 동작하며, OnGet 메소드 내부에 작성된 코드는 초기 웹 호출때 실행되는 부분이라고 생각하면 된다.

반대로, OnPost 메소드는 첫 호출이후 웹 페이지에서 서버로 데이터를 보내거나 동작을 요청할 때 사용되는 HTTP 요청 메소드이다. 주로 어떠한 양식 (form)을 작성하여 제출할 때 많이 사용된다.

```html
@model EmptyProject.Pages.IndexModel

<body>
    <p>@Model.Meg.Message</p>

    <form method="post">
        <label asp-for="Meg.Message">Enter Message</label>
        <input type = "text" asp-for="Meg.Message"/>
    </form>
</body>
```

위의 코드는 cshtml 확장자를 가진 페이지의 한 부분이다.

`@mode EmptyProject.Pages.IndexModel`는 데이터를 모델과 뷰(또는 컴포넌트) 간에 연결하거나 연결하는 작업인 ‘바인딩’이라는 작업이다. 이를 통해 해당 페이지에서 `@Model` 이라는 키워드를 통해 지정한 모델의 데이터 흐름을 제어할 수 있게 된다.

`asp-for`는 ASP 프레임워크에서 자체적으로 개발하여 사용하고 있는 키워드로 표준 HTML 문법이 아니다. `asp-`로 시작하는 옵션을 사용할 때는 바인딩된 모델과 관련된 작업을 하는 것이기 때문에 현재 페이지에 바인딩된 모델을 자동으로 인식한다. 그때문에 위 코드와 같이 `@Model` 키워드 없이 사용할 수 있는 것이다.

MVC의 컨트롤러 부분을 잠시 살펴보자.

```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        HelloMessage msg = new HelloMessage()
        {
            Message = "Hello APP.Net !"
        };
        ViewBag.Noti = "This msg Dynamic Meg !";
        return View(msg);
    }
}
```

메소드의 반환 타입이 void도 아니고 View를 동작시키는 부분을 볼 수 있다. 그에 반해 Razor 페이지는 하나의 컨트롤러가 하나의 뷰에 이미 연결되어 있으므로 반환이 필요없다.

웹 앱 설정을 해주는 진입 부분의 설정으로는 

`builder.Services.AddControllersWithViews()`

부분이 `builder.Services.AddRazorPages()`으로 변경되며,

라우팅 부분에는 `app.MapControllerRoute`대신 

`app.MapRazorPages`를 사용해준다.

기본적으로 MVC의 라우팅은 설정 코드에서 라우팅 주소를 지정을 해주었기 때문에 기본 주소가 설정되어 그것을 기준으로 동작하게끔 되어 있다. 반면, Razor 기법은 기본적으로 `Pages` 이름의 폴더가 기본 라우팅 주소가 되어 동작한다. 

또한, 뷰 페이지에서 컨트롤러에게 통신을 보낼 때 MVC 패턴을 사용할 때는 아래와 같이 **컨트롤러/액션**의 주소를 지정해주어야 했다.

```html
<form asp-controller="Home" asp-action="Index" method ="post"> 
		<input type="text" asp-for="Message"/>
		<button type="submit">submit</button>
</form>
```

하지만 Razor Pages 같은 경우에는 바인딩된 모델이 존재하므로 목적지를 명시해주지 않아도 **어떤 타겟에서 데이터를 보내고 받을 지 알고 있으므로 해당 부분이 생략된다.**

번거로운 여러 작업들을 자동으로 해주기 때문에 MVC 패턴의 개발보다 작업 속도가 빠른 편이다.
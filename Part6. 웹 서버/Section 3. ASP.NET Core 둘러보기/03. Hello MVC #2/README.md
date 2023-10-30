# Section 3.2 Hello MVC #2
## Views


컨트롤러의 제어를 받는 View 페이지를 작성해줘야 한다. 

컨트롤러 생성의 기본값으 `HomController`이고 그것을 변경해주지 않았다면 `Views` 폴더 내부에 `Home`이라는 폴더를 생성하여 그 내부에 `HomeController`의 메소드에 맞춰 여러 html 파일을 만들어줘야 한다.

`새 항목→Razor 뷰(비어있음)`를 선택하여 이름을 정해주면 `cshtml` 확장자를 가지는 특수한 파일이 생성된다. 해당 확장자는 **C# 스크립트와 HTML 문법을 혼합하여 사용할 수 있는 특수한 파일 확장자**이다.

```csharp
namespace Empty.Models
{
    public class HelloMessage
    {
        public string Message { get; set; } 

    }
}
```

```html
<!-- Views/Home/Index.cshtml -->
@model Empty.Models.HelloMessage

<html>
<head>
<body>
		<h1>@Model.Message</h1>
</body>
</head>
</html>

```

일반 HTML 문서와 다르게 @를 사용하여 C# 클래스를 가져와 사용할 수 있다. 

위와 같이 사용하게 되면 `HomeController`의 `Index` 메소드의 반환값이 Model변수로 오게 되고 해당 변수의 모습이 `HelloMessge` 클래스로 정의되었으니 멤버변수 `Message`의 값을 사용할 수 있는 것이다.

**즉, 컨트롤러 부분에서 `IActionResult` 타입의 메소드 이름으로 같은 이름의 뷰 페이지에 대한 통신을 할 수 있다.**

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

`ViewBag`은 MVC 프로젝트에서 사용되는 컨트롤러와 뷰 간의 데이터 공유를 위한 동적 객체이다. 데이터 타입이 동적으로 결정되는 객체이며 컨트롤러에서 사용된 `ViewBag` 데이터는 뷰에서 읽어서 사용할 수 있다. 

```html
<!-- Views/Home/Index.cshtml -->
@model Empty.Models.HelloMessage

<html>
<head>
<body>
		<h1>@Model.Message</h1>
		<h2>@ViewBag.Noti</h2>
</body>
</head>
</html>
```

## View에서 보낸 데이터 처리하기


웹 통신을 처리해주는 다양한 프로그래밍 언어에서도 유사하게 사용되며 C#에서는 **[HttpPost] 어트리뷰트**를 사용하여 처리한다.

```csharp
[HttpPost]
public IActionResult Index(HelloMessage meg)
{
    ViewBag.Noti = "Chagned ViewBag";
    return View(meg);
}
```

Index 뷰 페이지에서 Post 방식으로 메시지를 보내오면 받아서 처리하는 부분이다. 이를 사용하기 위해서는 뷰 페이지에서 데이터를 Post 방식으로 보내주는 부분의 코딩도 필요하다.

```html
<form asp-controller="Home" asp-action="Index" method ="post"> 
		<input type="text" asp-for="Message"/>
		<button type="submit">submit</button>
</form>
```

- **`asp-controller`** 속성은 양식이 제출될 때 처리할 컨트롤러를 지정한다 이 코드에서는 "Home" 컨트롤러를 사용한다.
- **`asp-action`** 속성은 양식이 제출될 때 실행할 액션 메서드를 지정한다. 이 코드에서는 "Index" 액션 메서드를 호출한다.
- **`asp-for`** 속성은 ASP.NET Core MVC의 모델 바인딩을 통해 서버로 데이터를 전송하는 데 사용된다. 이 코드에서는 "Message"라는 모델 속성에 바인딩된다. 해당 페이지에서 모델을 바인딩 했기 때문에 속성의 이름만 입력해주어도 어떤 모델인지 알 수 있는 것이다.


💡 **TagHelpers**

**위 코드 방식은 ASP 프레임워크에서만 사용할 수 있으며 이를 위해 Views 폴더에 특정 TagHelper를 임포트시켜야 한다.**

```csharp
@using Empty
@using Empty.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```


## **MVC 프레임워크 진입점**

---

MVC 프로젝트를 생성하게 되면 일반적으로 `Program.cs` 라는 진입점 프로그램이 함께 작성된다. **해당 파일은 뷰 엔진, 주소 라우팅, 데이터베이스 연결 등과 같은 필수 구성 요소를 설정하는 데 사용된다.** 

일반적인 콘솔 프로그램과 같이 Main 으로 시작되며 `WebApplication.CreateBuilder`를 통해 빌더 객체를 생성하고 어떤 방식으로 실행할 지를 고르고 실행하는 부분으로 시작하여 라운팅 하는 부분과 어떤 기능들을 쓸 것인지를 설정한다.

```csharp
public static void Main(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllersWithViews();
		//해당 부분을 통해 MVC 패턴을 사용한다는 것을 명시한다.
    var app = builder.Build();
   
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
```

중요한 부분은 MapControllerRoute라고 볼 수 있다. 해당 부분은 웹 페이지의 주소에 대한 라우팅을 하는 부분으로 입구를 설정하는 컨트롤러의 액션을 설정하여 웹 페이지의 초기 화면을 결정한다.

이 코드에서는 `HomeController`의 `Index` 액션 메소드의 실행 결과인 `Home/Index.cshtml`이 초기 화면으로 지정되어 웹 앱이 실행된다.
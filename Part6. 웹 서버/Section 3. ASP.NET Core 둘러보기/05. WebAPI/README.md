# Section 3.5 WebAPI
## WebAPI


WebAPI 는 다른 웹 페이지와 달리 사용자에게 보여주기 위한 View 기능이 없다. **즉, 데이터를 담기 위한 모델과 데이터를 컨트롤하기 위한 컨트롤러 부분만 존재한다.**

`Controllers` 폴더에 `[ 새 항목 ] → [ API 컨트롤러 : 비어있음 ]` 버튼을 클릭하여 컨트롤러를 생성해준다. 디폴트 이름은 ValueController로 설정되어 있다.

```csharp
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
    }
}
```

**API 컨트롤러는 기본적으로 라우팅을 각 파일에서 해준다.** 

웹에 처음으로 접근을 하게 되면 GET 방식의 통신이 이뤄지게 된다. 이는 API 웹 서버도 마찬가지이며 Get 이라는 메소드를 작성하여 첫 호출에 행해질 동작을 작성해준다.

```csharp
public class ValuesController : ControllerBase
{
    [HttpGet]
    public List<HelloMessage> Get()
    {
        List<HelloMessage> msg = new List<HelloMessage>(); ;
        msg.Add(new HelloMessage() { Meg = "Hello Web API 1 !" });
        msg.Add(new HelloMessage() { Meg = "Hello Web API 2 !" });
        msg.Add(new HelloMessage() { Meg = "Hello Web API 3 !" });

        return msg;
    }
}
```

중요한 점은 `[HttpGet]` 이라는 어트리뷰트를 설정해주어야만 Get 방식의 호출에서 사용할 메소드를 정상적으로 지정할 수 있게 된다는 점이다.

MVC 패턴의 웹과는 달리 `Controller`에서의 반환이 `View`가 아닌 `실제 데이터 타입`을 반환해주고 있다. **UI로 표현할 필요가 없기 때문에 실제 데이터를 호출한 상대방에게 직접 보내주는 것이다.**

웹 설정 코드를 살펴보면 서비스를 컨트롤 하는 부분은 `builder.Services.AddControllers` 로 설정되며, 라우팅을 해주는 기능은 `app.MapControllers`로 설정되어 있다.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
app.MapControllers();
```

`index 페이지`가 없기 때문에 웹에 접속을 하더라도 어떤 화면도 출력되지 않고 `API 컨트롤러`의 라우팅 주소를 입력해주게 되면 해당 코드에서 작성하여 반환한 데이터가 JSON 형태로 감싸져 보여지게 된다. **(일반적으로 JSON으로 통신하지만 설정을 통해 변경해줄 수 있다)**
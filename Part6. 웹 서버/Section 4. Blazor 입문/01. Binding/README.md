# Section 4.1 Binding
## Binding

---

Blazor 서버 앱 템플릿을 이용한 개발은 Razor 컴포넌트들을 조합하는 방식이 메인으로 동작하게 된다. 물론 컴포넌트 자체가 하나의 페이지처럼 동작하는 경우도 있다. 

💡 **Razor 컴포넌트의 두 가지 쓰임새**

Razor 컴포넌트는 그 자체로 웹 페이지 주소로 라우팅되어 사용할 수도 있으고 또 다른 컴포넌트에 바인딩되어 사용되기도 한다. 

만약 그 자체로 페이지처럼 사용되는 경우에는 아래와 같이 문서에 **`@page 키워드`**를 사용하여 라우팅해주는 부분이 존재한다. **또한 템플릿에서 Pages 폴더 내부에 작성된다는 특징이 있다.** 

```html
**@page "/"**
@using Microsoft.AspNetCore.Components.Web
@namespace BlazorServerApp.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

<!DOCTYPE html>
...
```

컴포넌트로써 다른 컴포넌트에 바인딩되어 사용될 목적인 Razor 컴포넌트는 page키워드 없이 일반적인 뷰 + 컨트롤러 문서로 작성된다. 일반적으로 `Shared 폴더`에 저장되어 관리된다.

Razor 컴포넌트는 크게 세 가지 구역으로 나눠져 있다. 

첫 번째 구역으로는 메타데이터 설정을 하는 부분이 있다.

```html
@page "/"
@using Microsoft.AspNetCore.Components.Web
@namespace BlazorServerApp.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

두 번째 구역으로는 HTML 태그 + ASP 문법으로 이루어진 UI와 관련된 기능을 하는 부분이 있다. **@를 이용하여 바인딩이나 C# 문법을 사용할 수 있다.**

```html
<PageTitle>Weather forecast</PageTitle>

<h1>Weather forecast</h1>

<p>This component demonstrates fetching data from a service.</p>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
                <tr>
                    <td>@forecast.Date.ToShortDateString()</td>
                    <td>@forecast.TemperatureC</td>
                    <td>@forecast.TemperatureF</td>
                    <td>@forecast.Summary</td>
                </tr>
            }
        </tbody>
    </table>
}
</html>
```

마지막으로 C#으로 작성된 컨트롤러 코드 부분이 있다.

```html
@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
    }
}
```

실습을 위해 Blazor 컴포넌트를 하나 생성하여 Binding 이라는 이름으로 페이지 라우팅을 진행해준다.

```html
@page "/binding"

<h3>Binding</h3>
<p>Value : @_value</p>

@code {
	int _value = 15;
}
```

`@_value` 를 사용하여 변수 바인딩을 하고 있다. 이런 식으로 컨트롤러 부분에서 뷰 부분으로 한방향으로만 가는 바인딩을 **`원사이드 바인딩`**이라 부른다. 

반대로 페이지에서 컨트롤러 부분의 변수를 변경하는 것도 가능하다. 일반적으로 `<input/>태그`를 사용하여 `@bind-value`에 역으로 변수를 지정해주면 된다. 

```html
<input type="range" step="1" @bind-value="_value"/>
```

만약 실시간으로 변경되는 것을 반영하기 위해서는 아래와 같이 옵션을 추가해주면 된다.

```html
<input type="range" step="1" @bind-value="_value" @bind-value:event="oninput"/>
```

`input 태그`에 대한 부분은 직접 찾아보며 HTML 태그 지식을 쌓아 나가는 것도 중요하다.

이후 샘플 페이지의 메뉴에 해당하는 NavMenu.razor 파일에 기존 내용을 복사하여 필요한 부분만 변경해준다. (NavLink에 연결된 페이지, 출력될 텍스트)

```html
<div class="nav-item px-3">
    <NavLink class="nav-link" href="binding">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Binding
    </NavLink>
</div>
```
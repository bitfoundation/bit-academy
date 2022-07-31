<div dir="rtl">
  
## جلسه ششم- پیاده‌سازی TodoList	
  
در این جلسه می خواهیم به پیاده‌سازی یک TodoList ساده همانند تصویر زیر بپردازیم.

<img src="images/img-1-1.png" />

ابتدا فایل جدیدی به نام TodoPage.razor در پوشه pages ایجاد کرده و کد زیر را به منظور تعیین آدرس این صفحه در ابتدای این فایل قرار می دهیم.

<div dir="ltr">

```razor

  @page "/todo"

``` 
</div>

سپس برای افزودن استایل‌ها فایل جدیدی به نام TodoPage.razor.scss با محتوای زیر ایجاد می کنیم.

<div dir="ltr">

```css

  .container {
    margin: 40px auto;
    max-width: 500px;

    .todo-count {
        margin-bottom: 20px;
        font-size: 80px;
        font-weight: 100;
        text-align: center;
        color: rgba(175, 47, 47, 0.15);
        text-rendering: optimizeLegibility;
    }

    input {
        width: 100%;
        padding: 10px;
    }

    .searchbox {
        margin: 10px 0;
    }

    .todo-add {
        display: flex;
        padding: 10px;
        border: none;
        background: rgba(0, 0, 0, 0.003);
        box-shadow: inset 0 -2px 1px #cecece;
        font-size: 27px;
    }

    .todo-app {
        background: #fff;
        margin: 20px 0 40px 0;
        position: relative;
        box-shadow: 0 2px 4px 0 #ccc;
    }

    .todo-item {
        display: flex;
        flex-direction: row;
        align-items: center;
        padding: 15px;
        border-bottom: 1px solid #e6e6e6;
        margin: 10px 0;
    }

    .todo-title {
        display: flex;
        align-items: center;
        flex: auto;
    }

    .filters {
        list-style: none;
        display: flex;
    }

    .todo-action {
        display: flex;
        width: 120px;
        justify-content: flex-end;
    }

    .footer {
        display: flex;
        flex-direction: row;
        align-items: center;
        color: #777;
        font-size: 14px;
    }
}


``` 
</div>

در ادامه فایلی با نام TodoItem.cs به ریشه پروژه اضافه کنید.  

<img src="images/img-2.png" />

در این فایل قرار است کلاسی به نام TodoItem داشته باشیم که این کلاس شامل فیلدهای مربوط به یک مورد todo می‌باشد. 

<div dir="ltr">

```c#

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsDone { get; set; }

    public bool IsEdit { get; set; } = false;
}

``` 
</div>

همانطور که در کد بالا می بینید قرار است هر کدام از Todo ها، شامل چهار فیلد Id, Title, IsDone و IsEdit  با مقدار پیشفرض  false باشد.

سپس فایل جدیدی به نام TodoPage.razor.cs ایجاد می‌کنیم.

برای نگهداری Todo ها باید از یک لیست استفاده کنیم. یک لیست مجموعه‌ای از object های قابل دسترسی است که قابلیت جستجو، مرتب کردن و تغییر دادن اعضای داخل آن را برای ما فراهم می کند.

در این فایل، ابتدا یک متغیر به نام TodoList  ازنوع List برای TodoItem ها  به صورت زیر ایجاد می‌کنیم. در ادامه قرار است در فایل TodoPage.razor از این متغیر به منظور نگهداری وضعیت لیست Todo ها استفاده کنیم.

<div dir="ltr">

```c#

using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
    }
}

``` 
</div>

بدین‌ترتیب یک لیست از روی کلاس TodoItem که از قبل در فایل TodoItem.cs ایجاده کرده بوده‌ایم، می‌سازیم.

به فایل TodoPage.razor  برمیگردیم.

در این مرحله، باید بتوانیم اعضای داخل لیستی را که تعریف کرده‌ایم، نمایش دهیم. البته در حالت اولیه هیچ آیتمی داخل لیست ما موجود نیست، اما ابتدا این بخش از کد را می‌نویسیم و در مرحله بعد کد مربوط به افزودن یک Todo جدید به لیست را، اضافه می‌کنیم که بتوانیم به تعداد دلخواه به لیست موجود آیتم اضافه کنیم. 

در HTML برای نمایش یک List از تگ ul استفاده می کنیم. ul  مخفف Unordered List و به معنای لیستی که در آن ترتیب اعضا مهم نیست می‌باشد و برای نمایش آیتم‌های داخل لیست از تگ li استفاده می‌کنیم.

تصویر زیر نحوه استفاده از تگ ul و تگ li را، برای نمایش یک لیست فرضی نشان می دهد.

<img src="images/img-3.png"/> 

در مثالی که در تصویر بالا آمده ، یک لیستی را داریم که اعضای آن ثابت و یا به اصطلاح static است. به این معنا که ما از قبل تعداد اعضای داخل لیست و محتوای آن را در نظر گرفته‌ایم، اما در TodoList ، ما اطلاعی از این که کاربر چه تعداد آیتم می‌خواهد به لیستمان (TodoList) اضافه و یا از لیست کم کند و یا این که اصلا محتوای آیتم‌های آن چه باشد نداریم، پس در واقع ما یک لیستی داریم که به صورت پویا و به اصطلاح dynamic تعداد اعضای آن اضافه و کم می‌شود و محتوای آیتم های آن تغییر می‌کند.

در این جور مواقع ما باید از دستوری استفاده کنیم که لیست موجود را گرفته و شروع کند آیتم به آیتم اعضای لیست را پیمایش کردن، حالا در حین این پیمایش ما می‌توانیم دستوری اضافه کنیم که اگر به فلان آیتم رسیدی به عنوان مثال نامش را تغییر بده و یا اصلا آیتم را حذف کن و یا اینکه به هر آیتمی که رسیدی محتوای آن آیتم را به کاربر نشان بده.

ما می‌توانیم از دستور foreach برای پیمایش اعضای یک لیست به صورت زیراستفاده کنیم.

<img src="images/img-4.png" />

<div dir="ltr">
  
```razor  
@page "/todo";

<div class="container">
  <ul>
    @foreach (TodoItem todo in TodoList)
    {
        <li>@todo.Title</li>
    }
  </ul>
</div>

``` 

</div>

در کد بالا، از یک دستور foreach برای پیمایش لیست TodoList استفاده کرده‌ایم. همانطور که در کد بالا می‌بینید هر کدام از اعضای این لیست را یک todo از نوع کلاس TodoItem که قبلا ایجاد کرده بودیم نامگذاری کرده‌ایم. سپس در تگ li عنوان مربوط به هر todo را نمایش داده‌ایم. در واقع با این دستور ما یک حلقه ایجاد کرده‌ایم که به ازای هر کدام از اعضای لیست، یک تگ li ایجاد می کند و عنوان مربوط به همان عضو را داخل li میگذارد. این روال تا آخرین عضو مربوط به این لیست ادامه دارد.

در کامپوننت‌های ‌Bit ما کامپوننتی به نام BitBasicList برای نمایش لیست داریم. در این کامپوننت علاوه بر نمایش اعضای لیست، موارد دیگر مانند صفحه بندی یا Pagination و مواردی که باعث کارایی بهتر نسبت به دیگر دستورات می‌شود را داریم.

بنابراین کامپوننت BitBasicList را به صورت زیر جایگزین دستور foreach می‌کنیم. 
  
<div dir="ltr">
  
```razor

<div class="container">

  <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
      <RowTemplate Context="TodoItem">
          <div Class="todo-item">
              <div class="todo-title">
                  <span>
                      @TodoItem.Title
                  </span>
              </div>
          </div>
      </RowTemplate>
  </BitBasicList>

</div>

``` 

</div>


در کامپوننت BitBasicList پراپرتی Items این کامپوننت را، با متغیری که از قبل برای لیست Todoها (TodoList) ایجاد کرده‌ایم مقداردهی می کنیم.
همچنین RowTemplate داخل این کامپوننت مربوط به هر عضو از TodoList  که از نوع TodoItem بوده می‌باشد، همانطور که می‌بینید شما می‌توانید هر آنچه را که از TodoItem می‌خواهید به کاربر نمایش دهید را داخل RowTemplate بگذارید.

در همین مرحله همچنین می‌خواهیم وضعیت تکمیل شدن یا نشدن یک Todo را هم به کاربر نمایش دهیم. برای این  منظور می توانیم از تگ input با "type="checkbox به صورتی که در تصویر زیر آمده استفاده کنیم.

<img src="images/img-5.png" />

هر input با "type="checkbox تنها می‌تواند شامل دو مقدار checked و یا unchecked از نوع boolean باشد.

همانطور که ‌می‌بینید کنار تگ input از یک تگ label هم استفاده شده است. با وجود تگ label شما می ‌توانید برای checkbox مربوطه عنوانی را تعیین نمایید، همچین منطقه بیشتری برای checked کردن یا unchecked کردن checkbox دارید چرا که حتی اگر روی مقداری که برای label در نظر گرفته‌اید هم کلیک کنید، checkbox شما تغییر وضعیت می‌دهد.

توجه فرمایید که در مثال بالا مقداری که برای ویژگی id تگ input در نظر گرفته شده است با مقداری که برای ویژگی for تگ label در نظر گرفته شده یکی می‌باشد. بدین صورت ما می توانیم مشخص کنیم که کدام Label مربوط به کدام input است.

ما در کامپوننت‌های Bit برای input با تایپ checkbox هم کامپوننتی به نام BitCheckbox را داریم که می توانیم از آن به صورت زیر در کد استفاده کنیم.

<div dir="ltr">
  
```razor

<div class="container">
  <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
      <RowTemplate Context="TodoItem">
          <div Class="todo-item">
              <div class="todo-title">
                  <BitCheckbox />
                  <span>
                      @TodoItem.Title
                  </span>
              </div>
          </div>
      </RowTemplate>
  </BitBasicList>
</div>

``` 

</div>
  
در ادامه می خواهیم کد مربوط به افزودن یک Todo جدید را بنویسیم.

بدین ترتیب ابتدا یک متغیر جدید به نام TodoName در فایل  TodoPage.razor.cs  اضافه می کنیم.

<div dir="ltr">

```c#

using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
        public string TodoName { get; set; }
    }
}

``` 
</div>

سپس در فایل TodoPage.razor یک input قرار داده و متغیر TodoName را به آن bind  می‌کنیم و می خواهیم روی رویداد onkeyup این input  یک متد به نام AddTodo را فراخوانی کنیم. 

رویداد onkeyup زمانی رخ می دهد که کاربر یک کلید (روی صفحه کلید) را رها می کند. 

کد تغییر یافته این فایل به صورت زیر می‌باشد.

<div dir="ltr">
  
```razor

<div class="container">
  <div class="todo-add">
      <input @bind="@TodoName" @onkeyup="@AddTodo" placeholder="Add a new todo" />
  </div>

  <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
      <RowTemplate Context="TodoItem">
          <div Class="todo-item">
              <div class="todo-title">
                  <BitCheckbox />
                  <span>
                      @TodoItem.Title
                  </span>
              </div>
          </div>
      </RowTemplate>
  </BitBasicList>

</div>

``` 
</div>

در ادامه متد AddTodo را به کلاس TodoPage به صورت زیر اضافه می‌کنیم.

ٖ<div dir="ltr">

```c#

using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
        public string TodoName { get; set; }
        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(TodoName))
            {
                var newTask = new TodoItem()
                {
                    Id = TodoList.Count() + 1,
                    Title = TodoName,
                    IsDone = false
                };

                TodoList.Add(newTask);
                TodoName = null;
            }
        }
    }
}

``` 
</div>

متد IsNullOrWhiteSpace در #C یک string method است. برای بررسی این که رشته مشخص شده خالی یا فقط شامل کاراکترهای space است استفاده می شود. اگر به یک رشته مقداری اختصاص داده نشده باشد یا صراحتاً مقدار null به آن اختصاص داده شده باشد،آن رشته null خواهد بود.

در متد AddTodo در کد بالا، تعیین کرده‌ایم که اگر مقدار TodoName مخالف null بود، یک object جدید از کلاس TodoItem ساخته و مقادیر تعیین شده به فیلدهای todo جدید اختصاص داده شود.

برای ایجاد یک object جدید از یک کلاس از کلمه کلیدی new قبل از نام کلاس استفاده می کنیم.
 
بدین صورت که برای مقدار Id تعداد todo های موجود در لیست را با استفاده از متد از پیش تعریف شده Count گرفته و یک واحد به آن اضافه کرده و به Id نسبت می‌دهیم.

مقدار TodoName یا همان نامی که کاربر داخل input به عنوان نام todo جدید وارد کرده را به Title نسبت می‌دهیم.

و در نهایت مقدار false را هم به IsDone نسبت می‌دهیم چرا که Todo جدید است و هنوز انجام نشده.

بعد از ایجاد و مقدار دهی Todo جدید، Todo جدید را باید با استفاده از متد ()Add لیست‌ها به انتهای TodoList اضافه کنیم.

 بعد از اضافه کردن TodoName را با مقدار null مقداردهی می کنیم.

در این مرحله می‌توانیم یک شرط برای نمایش لیست Todo ها قرار دهیم به این صورت که اگر تعداد آیتم‌های لیست بیشتر از صفر بود، لیست را نمایش دهد.

<div dir="ltr">
  
```razor

<div class="container">
  <div class="todo-add">
      <input @bind="@TodoName" @onkeyup="@AddTodo" placeholder="Add a new todo" />
  </div>
  @if (TodoList.Count > 0)
  {
    <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
        <RowTemplate Context="TodoItem">
            <div Class="todo-item">
                <div class="todo-title">
                    <BitCheckbox />
                    <span>
                        @TodoItem.Title
                    </span>
                </div>
            </div>
       </RowTemplate>
    </BitBasicList>
  }
</div>

``` 

</div>

در ادامه می خواهیم هر Todo داخل لیست امکان ویرایش و حذف را نیز داشته باشد.
  
بدین منظور از دو کامپوننت BitIconButton برای فراخوانی دو متد EditTodoItem و DeleteTodoItem داخل لیست استفاده می‌کنیم.

کد بالا به صورت زیر تغییر می‌کند.

<div dir="ltr">
  
```razor

<div class="container">
  <div class="todo-add">
      <input @bind="@TodoName" @onkeyup="@AddTodo" placeholder="Add a new todo" />
  </div>
  @if (TodoList.Count > 0)
  {
    <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
        <RowTemplate Context="TodoItem">
            <div Class="todo-item">
                <div class="todo-title">
                    <BitCheckbox />
                    <span>
                        @TodoItem.Title
                    </span>
                </div>

                <div class="todo-action">
                    <BitIconButton IconName="BitIconName.Edit" OnClick="(e => EditTodoItem(TodoItem))" />
                    <BitIconButton IconName="BitIconName.Delete" OnClick="(e => DeleteTodoItem(TodoItem))" />
                </div>
            </div>
       </RowTemplate>
    </BitBasicList>
  }
</div>

``` 

</div>

کدهای HTML مربوط به رندر کامپوننت BitIconButton به صورت تصویر زیر می‌باشد.

<img src="images/img-6.png" />
 
همانطور که در تصویر بالا می‌بینید کامپوننت BitIconButton تشکیل شده است از یک تگ button که داخل آن یک تگ span قرار گرفته و داخل تگ span هم یک تگ i برای نمایش icon مورد نظر قرار گرفته است که به هر کدام از آنها یک فونت آیکن می‌گویند. فونت آیکون‌ها فونت هایی هستند که به جای حروف یا اعداد ، دارای نمادها و آیکن‌ها هستند. با فونت آیکن‌ها می‌توانید مانند متن معمولی رفتار کنید به این صورت که هر پراپرتی CSS که به متن اختصاص می‌دهید مثل font-size، color می‌توانید به آنها هم اختصاص دهید.

شما می‌توانید لیست کامل این فونت آیکن‌ها را در لینک زیر ببینید. 

https://uifabricicons.azurewebsites.net

اگر نام هر کدام از فونت آیکن‌های موجود در این لیست را به پارامتر IconName کامپوننت BitIconButton اختصاص دهید، button شما شکل آن آیکن را به خود می‌گیرد.

برخی از این فونت آیکن‌ها در تصویر زیر آمده است.

<img src="images/img-7.png" />

پارامتر بعدی که در استفاده از کامپوننت BitIconButton به کار بردیم پارامتر OnClick می‌باشد به این معنا که وقتی روی این دکمه کلیک کردیم یک اتفاقی بیفتد. مقداری که به این پارامتر در BitIconButton اول اختصاص داده‌ایم عبارت (e => EditTodoItem(TodoItem)) می‌باشد. به این عبارت در #Lambda expression ،C می‌گوییم. از یک عبارت lambda برای ایجاد یک anonymous function استفاده می کنیم. از عملگر <= در Lambda برای جدا کردن لیست پارامترهای lambda، از بدنه آن استفاده می‌کنیم.

برای ایجاد عبارت lambda، پارامترهای ورودی را در صورت وجود در سمت چپ عملگر lambda و یک عبارت یا یک بلاک دستور را در طرف دیگر مشخص می کنیم.

با استفاده از این عبارت با هر بار کلیک بر روی این دکمه متد EditTodoItem فراخوانی شده و مقادیر TodoItem جاری به آن اختصاص داده می‌شود.

در مرحله بعد می‌خواهیم متد مربوط به حذف شدن یک Todo از لیست را بنویسیم. بدین منظور به فایل TodoPage.razor.cs رفته و کد مربوط به این متد را به صورت زیر به این فایل اضافه می‌کنیم.

<div dir="ltr">

```c#

using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
        public string TodoName { get; set; }
    }

    private void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(TodoName))
        {
            var newTask = new TodoItem()
            {
                Id = TodoList.Count() + 1,
                Title = TodoName,
                IsDone = false
            };

            TodoList.Add(newTask);
            TodoName = null;
        }

        private void DeleteTodoItem(TodoItem todo)
        {
            TodoList.Remove(todo);
        }
    }
}

``` 
</div>

همانطور که می‌بینید ورودی این متد یک todo از نوع TodoItem می‌باشد. همان مقداری که زمان فراخوانی این متد روی رویداد OnClick مربوط به دکمه Delete به آن اختصاص دادیم. دستوری که داخل این متد نوشته شده است به این معناست که روی لیست TodoList، متد از پیش تعریف شده Remove را فراخوانی کن و todo ای را که به عنوان پارامتر ورودی داده شده است را حذف کن.

مرحله بعدی مربوط به افزودن متد EditTodoItem است که مربوط به ویرایش یک todo می‌باشد. کد این متد به صورت زیر به فایل TodoPage.razor.cs اضافه می‌شود.

<div dir="ltr">

```c#

private void EditTodoItem(TodoItem todo)
{
  todo.IsEdit = true;
}

``` 
</div>

در این متد ما مقدار IsEdit مربوط به todo جاری که قصد ویرایشش را داریم را برابر با true قرار می‌دهیم.

در ادامه به فایل TodoPage.razor  می‌رویم و کد مربوط به این صفحه را به صورت زیر تغییر می‌دهیم.

<div dir="ltr">
  
```razor

<div class="container">
  <div class="todo-add">
      <input @bind="@TodoName" @onkeyup="@AddTodo" placeholder="Add a new todo" />
  </div>
  @if (TodoList.Count > 0)
  {
    <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
        <RowTemplate Context="TodoItem">
            <div Class="todo-item">
                <div class="todo-title">
                    <BitCheckbox />
                    @if (TodoItem.IsEdit)
                    {
                        <input @bind="@NewName" />
                        <BitIconButton IconName="BitIconName.Accept" OnClick="(e => EditTodo(TodoItem))" />
                        <BitIconButton IconName="BitIconName.Cancel" OnClick="(e => CancelEditTodo(TodoItem))" />
                    }
                    else
                    {
                        <span>
                            @TodoItem.Title
                        </span>
                    }
                </div>
                <div class="todo-action">
                    <BitIconButton IconName="BitIconName.Edit" OnClick="(e => EditTodoItem(TodoItem))" />
                    <BitIconButton IconName="BitIconName.Delete" OnClick="(e => DeleteTodoItem(TodoItem))" />
                </div>
            </div>
       </RowTemplate>
    </BitBasicList>
  }
</div>

``` 

</div>

همانطور که در کد بالا می‌بینید در div با کلاس todo-title  تغییری ایجاد کرده‌ایم. به این صورت که اگر مقدار IsEdit مربوط به TodoItem برابر با true بود، یعنی عنوان مربوط به todo باید ویرایش شود پس به جای نمایش عنوان مربوط به todo، یک input را نمایش می‌دهیم که متغیر NewName را که در مرحله بعد تعریف کنیم، به آن bind می‌کنیم و همچنین دو button داریم که یکی از آنها قرار است متدی به نام EditTodo را فراخوانی کرده و آن یکی متد CancelEditTodo را فراخوانی می‌کند.

در ادامه برای تعریف متغیر و متدهای مربوط به ویرایش یک todo، به فایل TodoPage.razor.cs برمی‌گردیم و کد مربوط به این فایل را به صورت زیر تغییر می دهیم.
 
<div dir="ltr">

```c#

using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
        public string TodoName { get; set; }
        public string NewName { get; set; }

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(TodoName))
            {
                var newTask = new TodoItem()
                {
                    Id = TodoList.Count() + 1,
                    Title = TodoName,
                    IsDone = false
                };

                TodoList.Add(newTask);
                TodoName = null;
            }
        }
    
        private void DeleteTodoItem(TodoItem todo)
        {
            TodoList.Remove(todo);
        }

        private void EditTodoItem(TodoItem todo)
        {
            todo.IsEdit = true;
        }

        private void EditTodo(TodoItem todo)
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                todo.IsEdit = false;
                todo.Title = NewName;
                NewName = null;
            }
        }

        private void CancelEditTodo(TodoItem todo)
        {
            todo.IsEdit = false;
            NewName = null;
        }
    }
}

``` 
</div>

در کد بالا ابتدا پارامتری به نام NewName و از نوع string را در بخش مربوط به تعریف متغیرها، تعریف کرده‌ایم.
 
سپس در ادامه متدها، متد EditTodo را اضافه کرده‌ایم. شرح مربوط به دستورات داخل این متد به این صورت است که بررسی می‌کنیم که اگر مقدار NewName مخالف null بود، ابتدا مقدار IsEdit مربوط به todo را برابر با false قرار داده و سپس مقدار NewName را به Title مربوط به todo اختصاص می‌دهیم و در نهایت مقدار null را به NewName اختصاص می‌دهیم.

در ادامه متد CancelEditTodo را داریم، این متد زمانی فراخوانی می‌شود که ما از تغییر دادن نام todo منصرف شده‌ایم، بنابراین در این متد بعد از اختصاص دادن مقدار false به متغیر IsEdit مربوط به todo مقدار NewName را برابر با null قرار می‌دهیم.

در ادامه می خواهیم متد مربوط به تکمیل شدن todo ها را بنویسیم به این صورت که اگر checkbox مربوط به هر todo را کاربر به حالت checked  تغییر داد، یعنی todo مربوط تکمیل شده است.

به این منظور ابتدا متد HandleTodoChange را به پارامتر OnChange کامپوننت BitCheckbox موجود در فایل TodoPage، به صورت زیر اختصاص می‌دهیم.

<div dir="ltr">
  
```razor

<BitCheckbox OnChange="() => HandleTodoChange(TodoItem)" />

``` 
</div>

برای اضافه کردن متد HandleTodoChange به فایل TodoPage.razor.cs رفته و کد زیر را به این فایل اضافه می‌کنیم.


<div dir="ltr">

```c#

private void HandleTodoChange(TodoItem todo)
{
    todo.IsDone = !todo.IsDone;
}

``` 
</div>

مجموع این دو قطعه کد به این صورت عمل کند که چون ما متد HandleTodoChange را به پارامتر OnChange اختصاص داده‌ایم با هر تغییر در وضعیت چک باکس (checked شدن و یا unchecked شدن) بلافاصله متد HandleTodoChange فراخوانی شده و وضعیت IsDone هر todo را مخالف وضعیت جاری قرار می‌دهد. 


 در ادامه می‌خواهیم امکان جستجو کردن یک todoItem را به TodoList مان اضافه کنیم.
 

بدین منظور ابتدا کامپوننت BitSearchBox را به صورت زیر به فایل TodoPage.razor اضافه می‌کنیم.

<div dir="ltr">
  
```razor

<div class="container">
  <div class="searchbox">
      <BitSearchBox Placeholder="Search" />
  </div>
  <div class="todo-add">
      <input @bind="@TodoName" @onkeyup="@AddTodo" placeholder="Add a new todo" />
  </div>
  @if (TodoList.Count > 0)
  {
    <BitBasicList Items="TodoList" Virtualize="true" Style="height: auto">
        <RowTemplate Context="TodoItem">
            <div Class="todo-item">
                <div class="todo-title">
                    <BitCheckbox OnChange="() => HandleTodoChange(TodoItem)" />
                    @if (TodoItem.IsEdit)
                    {
                        <input @bind="@NewName" />
                        <BitIconButton IconName="BitIconName.Accept" OnClick="(e => EditTodo(TodoItem))" />
                        <BitIconButton IconName="BitIconName.Cancel" OnClick="(e => CancelEditTodo(TodoItem))" />
                    }
                    else
                    {
                        <span>
                            @TodoItem.Title
                        </span>
                    }
                </div>
                <div class="todo-action">
                    <BitIconButton IconName="BitIconName.Edit" OnClick="(e => EditTodoItem(TodoItem))" />
                    <BitIconButton IconName="BitIconName.Delete" OnClick="(e => DeleteTodoItem(TodoItem))" />
                </div>
            </div>
       </RowTemplate>
    </BitBasicList>
  }
</div>

``` 
</div>

در ادامه به فایل TodoPage.razor.cs رفته و مجددا یک لیست جدید از روی کلاس TodoItem به نام FilteredTodoList به منظور نگه داشتن نتیجه سرچی که روی لیست اصلی انجام شده ایجاد می‌کنیم.

همچنین متغیر جدیدی به نام SearchTerm را هم به منظور نگه داشتن نام Todo سرچ شده به این قسمت اضافه می کنیم.

بدین ترتیب بخش اول کد این فایل که مربوط به تعریف پارامترها و متغیرها است به صورت زیر تغییر می‌کند.

<div dir="ltr">

```c#

 private List<TodoItem> TodoList = new();
 private List<TodoItem> FilteredTodoList = new();
 private string TodoName { get; set; }
 public string NewName { get; set; }
 private string SearchTerm;

``` 
</div>

به فایل Todopage.razor برمی‌گردیم، در کامپوننت BitSearchBox  پارامتری به نام OnSearch تعریف شده است که ما می توانیم با استفاده از این پارامتر تعیین کنیم، که زمانی که کاربر شروع به سرچ کردن می‌کند چه اتفاقی بیفتد.
 
پس پارامتر BitSearchBox را به این کامپوننت اضافه و متدی به نام HandleSearch را برای آن در نظر می‌گیریم.

<div dir="ltr">
  
```razor

<div class="searchbox">
    <BitSearchBox Placeholder="Search" OnSearch="HandleSearch" />
</div>

``` 
</div>

در ادامه می خواهیم متد HandleSearch را تعریف و به متدهای موجود اضافه کنیم.

در متد HandleSearch به صورت زیر، ابتدا واژه سرچ شده را به متغیر SearchTerm اختصاص داده و سپس متد Filter که در ادامه تعریف می کنیم را، فراخوانی می کنیم.

<div dir="ltr">

```c#

private void HandleSearch(string searchTerm)
{
    SearchTerm = searchTerm;
    Filter();
}
  
``` 
</div>

متد فیلتر را فعلا به صورت زیر تعریف می‌کنیم.

<div dir="ltr">

```c#

private void Filter()
{
    FilteredTodoList = TodoList.Where(item =>
    {
        var result = string.IsNullOrWhiteSpace(SearchTerm) || item.Title.ToLower().Contains(SearchTerm.ToLower());
        if (result is false) return false;
        return true;
    }).ToList();
}
  
``` 
</div>

سپس باید در BitBasicList  تغییری ایجاد کنیم که به جای این که آیتم‌ها را از روی TodoList بخواند آنها را از روی FilteredTodoList خوانده و لیست را بسازد در واقع FilteredTodoList همان لیست قبلی است با این تفاوت که اگر سرچی هم انجام شده نتیجه سرچ را هم داخل خودش دارد.

این قسمت از کد قبلی به صورت زیر تغییر می‌کند.


<div dir="ltr">
  
```razor
@if (FilteredTodoList.Count > 0)
{
    <BitBasicList Items="FilteredTodoList" Virtualize="true" Style="height: auto">
        <RowTemplate Context="TodoItem">
            <div Class="todo-item">
                <div class="todo-title">
                    <BitCheckbox OnChange="() => HandleTodoChange(TodoItem)"/>
                    @if (TodoItem.IsEdit)
                    {
                        <input @bind="@NewName" />
                        <BitIconButton IconName="BitIconName.Accept" OnClick="(e => EditTodo(TodoItem))" />
                        <BitIconButton IconName="BitIconName.Cancel" OnClick="(e => CancelEditTodo(TodoItem))" />
                    }
                    else
                    {
                        <span>
                            @TodoItem.Title
                        </span>
                    }

                </div>

                <div class="todo-action">
                    <BitIconButton IconName="BitIconName.Edit" OnClick="(e => EditTodoItem(TodoItem))" />
                    <BitIconButton IconName="BitIconName.Delete" OnClick="(e => DeleteTodoItem(TodoItem))" />
                </div>
            </div>

        </RowTemplate>
    </BitBasicList>
}

``` 
</div>


با استفاده از پارامتر OnClear این کامپوننت می‌توانیم متدی را برای زمانی که کاربر بر روی آیکن ( close ( X این کامپوننت کلیک کرد اختصاص دهیم.
 
پس ابتدا، پارامتر OnClear را به این کامپوننت مطابق زیر اضافه کرده و سپس متد HandleClear را تعریف و به متدهای قبلی اضافه می‌کنیم.

<div dir="ltr">
  
```razor

<div class="searchbox">
    <BitSearchBox Placeholder="Search" OnSearch="HandleSearch" OnClear="HandleClear" />
</div>

``` 
</div>
  

<div dir="ltr">

```c#

private void HandleClear()
{
    HandleSearch("");
}
  
``` 
</div>

همانطور که در کد بالا می‌بینید داخل متد HandleClear ما متد HandleSearch را صدا زده‌ایم و یک رشته خالی را به آن اختصاص داده‌ایم این رشته خالی داخل SearchTerm قرار گرفته و عملا چون هیچ واژه برای سرچ وجود ندارد، در کل سرچی انجام نمی‌شود.

در ادامه می خواهیم علاوه بر سرچی که نوشتیم آیتم‌ها را براساس فعال بودن(هنوز تکمیل نشده) و تکمیل شده فیلتر کنیم.

 بدین منظور از کامپوننت BitChoiceGroup و BitChoiceOption زیر استفاده کرده و کد قبلی را به صورت زیر می‌دهیم.

<div dir="ltr">
  
```razor
<div class="container">
    <div class="todo-count">
        <span>Todos(@TodoList.Count(todo => !todo.IsDone))</span>
    </div>
    
    <div class="searchbox">
        <BitSearchBox Placeholder="Search" OnSearch="HandleSearch" OnClear="HandleClear" />
    </div>

    <div class="todo-app">
        <div class="todo-add">
            <input @bind="@TodoName" @onkeyup="@AddTodo" placeholder="Add a new todo" />
        </div>

        @if (FilteredTodoList.Count > 0)
        {
            <BitBasicList Items="FilteredTodoList" Virtualize="true" Style="height: auto">
                <RowTemplate Context="TodoItem">
                    <div Class="todo-item">
                        <div class="todo-title">
                            <BitCheckbox OnChange="() => HandleTodoChange(TodoItem)"/>
                            @if (TodoItem.IsEdit)
                            {
                                <input @bind="@NewName" />
                                <BitIconButton IconName="BitIconName.Accept" OnClick="(e => EditTodo(TodoItem))" />
                                <BitIconButton IconName="BitIconName.Cancel" OnClick="(e => CancelEditTodo(TodoItem))" />
                            }
                            else
                            {
                                <span>
                                    @TodoItem.Title
                                </span>
                            }

                        </div>

                        <div class="todo-action">
                            <BitIconButton IconName="BitIconName.Edit" OnClick="(e => EditTodoItem(TodoItem))" />
                            <BitIconButton IconName="BitIconName.Delete" OnClick="(e => DeleteTodoItem(TodoItem))" />
                        </div>
                    </div>

                </RowTemplate>
            </BitBasicList>
        }
    </div>
    <div class="footer">
        <BitChoiceGroup>
            <BitChoiceOption Text="All" Value="All" />
            <BitChoiceOption Text="Active" Value="Active" />
            <BitChoiceOption Text="Completed" Value="Completed" />
        </BitChoiceGroup>
    </div>
</div>

``` 
</div> 

اضافه کردن این قسمت از کد باعث می‌شود خروجی به صورت زیر تغییر کند.

<img src="images/img-8.png"/> 

طبق روال گذشته می توانیم در قسمت DeveloperTools کد کامپایل شده این کامپوننت را ببینیم.

<img src="images/img-9.png"/> 

زمانی که می‌خواهیم مجموعه‌ای از گزینه‌های مرتبط را کنار هم داشته باشیم، می‌توانیم از input  با نوع radio و یا checkbox استفاده کنیم با این تفاوت که زمانی که شما از نوع checkbox برای input استفاده می‌کنید می‌توانید به صورت همزمان چندین گزینه را انتخاب کنید اما زمانی که از نوع radio برای input استفاده می‌کنید در هر لحظه فقط یه گزینه می تواند انتخاب شود.

در مورد label هم در درس‌های گذشته به صورت کامل توضیح داده‌ایم.

کامپوننت BitChoiceGroup پارامتری به نام OnValueChange دارد که با تغییر انتخاب بین گزینه‌ها، متدی که به آن اختصاص داده شده را فرا می‌خواند.
 
پس در ادامه نیاز داریم این پارامتر ار به این کامپوننت اضافه و متدی را به آن اختصاص دهیم.

<div dir="ltr">
  
```razor
  
<BitChoiceGroup OnValueChange="HandleFilterChange" Style="display: flex; flex-direction: row; gap: 20px">
    <BitChoiceOption Text="All" Value="All" />
    <BitChoiceOption Text="Active" Value="Active" />
    <BitChoiceOption Text="Completed" Value="Completed" />
</BitChoiceGroup>

``` 
</div>

در ادامه برای تعریف متد HandleFilterChange به فایل TodoPage.razor.cs رفته و در ابتدا متغیری به نام FilterValue را در قسمت مربوط به تعریف پارامترها و متغیر تعریف می‌کنیم.

<div dir="ltr">

```c#

private List<TodoItem> TodoList = new();
private List<TodoItem> FilteredTodoList = new();
private string TodoName { get; set; }
public string NewName { get; set; }
private string SearchTerm;
private string FilterValue;
  
``` 
</div>

همانطور که در کد بالا می‌بینید ما value حاصل از انتخاب گزینه ها را به FilterValue اختصاص داده و مجدد متد فیلتر را صدا می‌زنیم.

<div dir="ltr">

```c#

private void HandleFilterChange(string filter)
{
    FilterValue = filter;
    Filter();
}
  
``` 
</div>

در ادامه متد Filter را به صورت زیر تغییر می دهیم.

<div dir="ltr">

```c#

private void Filter()
{
    FilteredTodoList = TodoList.Where(item =>
    {
        var result = string.IsNullOrWhiteSpace(SearchTerm) || item.Title.ToLower().Contains(SearchTerm.ToLower());
        if (result is false) return false;
        if (string.IsNullOrWhiteSpace(FilterValue) is false)
        {
            switch (FilterValue)
          {
              case "Active":
                 return !item.IsDone;
              case "Completed":
                 return item.IsDone;
            }

        }
        return true;
    }).ToList();
}
  
``` 
</div> 

در کد اضافه شده به متد Filter گفته‌ایم که اگر مقدار FilterValue مخالف null و یا WhiteSpace بود، در کل FilterValue دارای مقدار بود در ادامه وارد بلاک مربوط به switch شود.

از دستور switch case می توان به جای دستور if..else استفاده کرد، زمانی که بیش‌تر از یک گزینه برای انتخاب وجود دارد.

دستور switch به طور کلی به صورت زیر تعریف می‌شود.

<img src="images/img-10.png"/>  


این دستور به این صورت کار می کند که ابتدا  switch expression یکبار ارزیابی می‌شود و سپس مقدار expression با مقدار هر case مقایسه و در صورت مطابقت بلاک کد مرتبط اجرا می‌شود. پس از اجرا اگر دستور break وجود داشته باشد اجرای کد در داخل بلاک متوقف شده و کار همین جا تمام می‌شود. اگر پیش‌بینی می‌کنیم که ممکن است مقدار expression با هیچ کدام از مقادیر case ها مطابقت نداشته باشد می‌توانیم از دستور default استفاده کنیم، در این صورت (عدم مطابقت مقادیر با هم) بلاک کد مربوط به دستور default اجرا می‌شود.

در کد بالا ما گفته‌ایم که اگر FilterValue دارای مقدار Active بود item هایی را برگردان که IsDone آنها false هست یعنی هنوز تکمیل نشده‌اند و فعال هستند و اگر FilterValue دارای مقدار Completed بود item هایی را برگردان که IsDone آنها ture هست به این معنی که این item ها تکمیل شده‌اند.

در نهایت هر جایی که تغییری در تعداد آیتم‌های موجود در لیست می‌دهیم مانند حذف کردن و یا اضافه شدن آیتم‌ها، باید متد  Filter را هم صدا بزنیم.

کدهای موجود در این فایل به صورت زیر تغییر می‌کند.


<div dir="ltr">

```c#

using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        private List<TodoItem> TodoList = new();
        private List<TodoItem> FilteredTodoList = new();
        private string TodoName { get; set; }
        private string NewName { get; set; }
        private string SearchTerm;
        private string FilterValue;

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(TodoName))
            {
                var newTask = new TodoItem()
                {
                    Id = TodoList.Count() + 1,
                    Title = TodoName,

                    IsDone = false
                };

                TodoList.Add(newTask);
                Filter();
                TodoName = null;
            }
        }

        private void DeleteTodoItem(TodoItem todo)
        {
            TodoList.Remove(todo);
            Filter();
        }

        private void EditTodoItem(TodoItem todo)
        {
            todo.IsEdit = true;
        }

        private void EditTodo(TodoItem todo)
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                todo.IsEdit = false;
                todo.Title = NewName;
                NewName = null;
            }
        }

        private void CancelEditTodo(TodoItem todo)
        {
            todo.IsEdit = false;
            NewName = null;
        }

        private void HandleTodoChange(TodoItem todo)
        {
            todo.IsDone = !todo.IsDone;
            Filter();
        }

        private void HandleClear()
        {
            HandleSearch("");
        }

        private void HandleSearch(string searchTerm)
        {
            SearchTerm = searchTerm;
            Filter();
        }

        private void HandleFilterChange(string filter)
        {
            FilterValue = filter;
            Filter();
        }

        private void Filter()
        {
            FilteredTodoList = TodoList.Where(item =>
            {
                var result = string.IsNullOrWhiteSpace(SearchTerm) || item.Title.ToLower().Contains(SearchTerm.ToLower());
                if (result is false) return false;
                if (string.IsNullOrWhiteSpace(FilterValue) is false)
                {
                    switch (FilterValue)
                  {
                      case "Active":
                         return !item.IsDone;
                       case "Completed":
                           return item.IsDone;
                    }

                }
                return true;
            }).ToList();
        }
    }
}
  
``` 
</div>
  
</div>


  

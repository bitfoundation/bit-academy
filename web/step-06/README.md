<div dir="rtl">
  
## جلسه ششم- پیاده‌سازی TodoList	
  
در این جلسه می خواهیم به پیاده‌سازی یک TodoList ساده همانند تصویر زیر بپردازیم.

<img src="images/1-1.png" width="500px"/>

ابتدا در پوشه pages فایل جدیدی به نام TodoPage.razor ایجاد کرده و کد زیر را به منظور تعیین آدرس این صفحه در ابتدای این فایل قرار می دهیم.

<div dir="ltr">

```razor

  @page "/todo";

``` 
</div>

در ادامه فایلی با نام TodoItem.cs به ریشه پروژه اضافه کنید.  

<img src="images/2.png" width="500px"/>

در این فایل قرار است کلاسی به نام TodoItem داشته باشیم که این کلاس شامل فیلدهای مربوط به یک مورد todo می‌باشد. 

<div dir="ltr">

```c#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

در این فایل، ابتدا یک متغیر به نام TodoList  ازنوع List برای todo item ها  به صورت زیر ایجاد می کنیم. در ادامه قرار است در فایل TodoPage.razor از این متغیر به منظور نگهداری وضعیت لیست todo ها استفاده کنیم.

<div dir="ltr">

```c#

using Microsoft.AspNetCore.Components.Web;
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

بدین‌ترتیب یک لیست از روی کلاس TodoItem که از قبل در فایل TodoItem.cs ایجاده کرده بوده‌ایم، ساختیم.

به فایل TodoPage.razor  برمیگردیم.

برای نمایش اعضای لیست یا همان Todo ها از کامپوننت BitBasicList کامپوننت های Bit به صورت زیر، استفاده می‌کنیم.
  
  
<div dir="ltr">
  
```razor

<div class="container">

  <BitBasicList Items="TodoList" Virtualize="true" Class="todo-list">
      <RowTemplate Context="TodoItem">
          <div Class="todo-item">
              <div class="todo-title">
                  <BitCheckbox @bind-IsChecked="TodoItem.IsDone"/>
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


در کد بالا پراپرتی Items این کامپوننت را، با متغیری که از قبل برای لیست Todo ها (TodoList) ایجاد کرده‌ایم مقداردهی می کنیم.
 
همچنین RowTemplate داخل کامپوننت BitBasicList هر سطر از لیست که یک TodoItem می‌باشد را ایجاد می‌کند، که همانطور که می‌بینید شما می‌توانید هر آنچه را که از TodoItem می‌خواهید به کاربر نمایش دهید داخل RowTemplate بگذارید.

در اینجا فعلا با استفاده از کامپوننت BitCheckbox وضعیت تکمیل شدن یا نشدن Todo  و با استفاده span عنوان Todo را نمایش داده‌ایم.

در ادامه می خواهیم کد مربوط به افزودن یک Todo جدید را بنویسیم.

بدین ترتیب ابتدا یک متغیر جدید به نام TodoName در فایل  TodoPage.razor.cs  اضافه می کنیم.

<div dir="ltr">

```c#

using Microsoft.AspNetCore.Components.Web;
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

  <BitBasicList Items="TodoList" Virtualize="true" Class="todo-list">
      <RowTemplate Context="TodoItem">
          <div Class="todo-item">
              <div class="todo-title">
                  <BitCheckbox @bind-IsChecked="TodoItem.IsDone"/>
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

using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Pages
{
    public partial class TodoPage
    {
        public List<TodoItem> TodoList = new();
        public string TodoName { get; set; }
    }

    public void AddTodo()
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

``` 
</div>

IsNullOrWhiteSpace در #C یک string method است. برای بررسی این که رشته مشخص شده خالی یا فقط شامل کاراکترهای space است استفاده می شود. اگر به یک رشته مقداری اختصاص داده نشده باشد یا صراحتاً مقدار null به آن اختصاص داده شده باشد،آن رشته null خواهد بود.

در متد AddTodo در کد بالا، تعیین کرده‌ایم که اگر مقدار TodoName مخالف null بود، یک object جدید از کلاس TodoItem ساخته و مقادیر تعیین شده به فیلدهای todo جدید اختصاص داده شود.

برای ایجاد یک object جدید از یک کلاس از کلمه کلیدی new قبل از نام کلاس استفاده می کنیم.
 
بدین صورت که برای مقدار Id تعداد todo های موجود در لیست را با استفاده از متد از پیش تعریف شده Count گرفته و یک واحد به آن اضافه کرده و به Id نسبت می‌دهیم.

مقدار TodoName یا همان نامی که کاربر داخل input به عنوان نام todo جدید وارد کرده را به Title نسبت می‌دهیم.

و در نهایت مقدار false را هم به IsDone نسبت می‌دهیم چرا که Todo جدید است و هنوز انجام نشده.

بعد از ایجاد و مقدار دهی Todo جدید، Todo جدید را باید با استفاده از متد ()Add لیست‌ها به انتهای TodoList اضافه کنیم.

 بعد از اضافه کردن TodoName را با مقدار null مقداردهی می کنیم.

</div>

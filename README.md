# Tomoto-Clock
## 程序功能：工作时间管理，结合工作计划的设置更好地管理自己的工作时间
		前台界面：时钟、TODOLIst、选择当前工作
		菜单：编辑工作计划、查看history
## Winform 前台界面
	界面设置：番茄（进度条） 倒计时
	界面初始化、Service类的初始化
## 工作计划类 （存储工作计划）
	天数 名称 时间（一周、每天）
	ToDolist 
	提供读写各种属性的方法
## Clock类 （在番茄钟计时时工作）
	工作计划对象
	总时间 （倒计时） todoList
	计时结束的提醒办法（铃声），返回相应值供service类检测然后进行相应的技术处理
	提供读写各种属性的方法，初始化可以传入
## History类 （存储历史记录）
	WorkList {workInfo(存储工作信息：名称、预计时间、本周（待定）完成情况)...（是否保留默认的学习计划待定）}
	提供WorkList的读写方法
	字段：
		List<WorkPlan> plans//存储工作计划
	方法：
			静态方法：
		public static int getDays(WorkPlan w)//获取计划天数
        public static void setDays(WorkPlan w, int days)//设置天数
        public static string getName(WorkPlan w)//获取计划名称
        public static void setName(WorkPlan w, string name)//设置计划名称
        public static List<Tomato> getTomatoList(WorkPlan w)//获取计划中的每日番茄表
        public static void AddTomato(WorkPlan w,TimeSpan ts)//添加番茄
        public static void DeleteTomato(WorkPlan w,int Sn)//删除番茄

        
## Service类 （整个程序的后台管理类，链接后台数据类与前台界面，管理程序中的各种数据，工作量偏大）
	WorkPlanList工作计划数组，存储用户的当前工作计划
	History对象
	clock对象
	提供WorkPlanList、History的初始化方法。数据获取与存储的方法待定
	给出供前台使用的调用、修改后台数据类（工作计划、历史记录、时钟）的数据
##WorkPlan类（）     2018/12/24/10.05   赵彪改
      属性：计划的名称(workName);string
                设定计划完成需要的天数（dayTime）;int
 	动态的番茄数组（tomatolist）；
      方法:  WorkPlan(string wkn,int dt)    //有参的构造函数
	WorkPlan()                             //无参的构造函数
public void addTomato(float Time,int signNumber) //给番茄数组增加一个新的番茄
       class Tomato:
                属性：float tomatoTime（番茄的时间）
 	          int signNumber     (这个番茄的标志)
                方法：Tomato(float Time,int sN)   //必须提供一个有参数的构造方法
## 工作的背景音乐
                

	
	
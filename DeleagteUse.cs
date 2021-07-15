using System;
public class Thread
    {

        public void Start(ThreadStartDelegate taskAddress , ThreadCallbackDelegate callbackAddress)
        {
            taskAddress.Invoke();
            callbackAddress.Invoke(true);
        }
        public void StartSearch(ThreadStartSearchDelegate taskAddress , ThreadCallbackSearchDelegate callbackAddress)
        {
            taskAddress.Invoke("searchKey");
            callbackAddress.Invoke("result");
        }
    }

   public  delegate void ThreadStartSearchDelegate(string searchkey);
   public  delegate void ThreadCallbackSearchDelegate(string result);


   public  delegate void ThreadStartDelegate();
   public  delegate void ThreadCallbackDelegate(bool isSuccess);

    class Program
    {
        static void Main(string[] args)
        {
            Button_Click();
        }

       static void Button_Click()
        {
            Console.WriteLine("Button Clicked");
            Thread _searchThread = new Thread();
           
            ThreadStartSearchDelegate _searchTaskAddress = new ThreadStartSearchDelegate(Program.SearchTask);
            ThreadCallbackSearchDelegate _updateUiAddress = new ThreadCallbackSearchDelegate(Program.UpdateUi);
            _searchThread.StartSearch(_searchTaskAddress , _updateUiAddress);

            Thread _updateTaskThread = new Thread();
            ThreadStartDelegate _updateTaskAddress = new ThreadStartDelegate(Program.UpdateTask);
            ThreadCallbackDelegate _updateTaskCallbackAddress = new ThreadCallbackDelegate(Program.UpdateCallback);
            _updateTaskThread.Start(_updateTaskAddress , _updateTaskCallbackAddress);

            Thread _deleteTaskThread = new Thread();
            ThreadStartDelegate _deleteTaskAddress = new ThreadStartDelegate(Program.DeleteTask);
            ThreadCallbackDelegate _deleteTaskCallbackAddress = new ThreadCallbackDelegate(Program.DeleteCallback);
            _deleteTaskThread.Start(_deleteTaskAddress ,_deleteTaskCallbackAddress);
           
        }
        
//         static void SearchWrapper()
//         {
//             SearchTask("null");
//         }
        
        static void SearchTask(string searchKey) { }
        static void  UpdateUi(string result) { }
        
        static void UpdateTask() { }
        static void UpdateCallback(bool isUpdateSuccess) { }
        static void DeleteTask() { }
        static void DeleteCallback(bool isUpdateSuccess) { }


    }

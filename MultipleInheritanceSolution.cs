using System;
public class Printer{
    public void Print(){
		Console.WriteLine("Printing Document"); 
	}
}
public class Scanner{
    public void Scan(){
		Console.WriteLine("Scanning Document");
	}
}
public interface Iprintable{
	void Print();
}

public interface Iscanable{
	void Scan();
}

public class PrintScanner : Iprintable ,Iscanable{
	
	Iprintable printer;
	Iscanable scanner;
	public PrintScanner(){}
	public PrintScanner(Iprintable printer){
		this.printer = printer;
	}
	public PrintScanner(Iscanable scanner){
		this.scanner = scanner;
	}
	
	
    public void Print(){
		Console.WriteLine("Printing Document using PrintScanner"); 
	}
	public void Scan(){
		Console.WriteLine("Scanning Document using PrintScanner");
	}
}

class DeviceManager{
    public void setPrinter(PrintScanner obj) {
		obj.Print();
	}
	public void setScanner(PrintScanner obj) {
		obj.Scan();
	}
	public void PrintDocument(){}
	public void ScanDocumnet(){}
}
public class Handler
{
	public static void main()
	{
		DeviceManager manager = new DeviceManager();
		manager.setPrinter(new Printer());
		manager.setPrinter(new PrintScanner());
		
		manager.setScanner(new Scanner());
		manager.setScanner(new PrintScanner());
		
	}
    
}

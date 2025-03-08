// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program {
    public static void Main() {
        Vector Vector1 = new Vector(3);
        Vector1.PonerElemento(1, 1);
        Vector1.PonerElemento(2, 2);
        Vector1.PonerElemento(3, 3);
        Vector Vector2 = new Vector(3);
        Vector2.PonerElemento(1, 1);
        Vector2.PonerElemento(2, 3);
        Vector2.PonerElemento(3, 3);
        Console.WriteLine(Vector1.Subconjunto(Vector2));
        Vector1.PrintVector();
        
    }
}
public class Vector{
    public int Longitud;
    private const int Max=1000;
    private int[] Elementos;
    public Vector(int longitud){
            Longitud = longitud;
            if(Longitud <= Max){
                Array.Resize(ref Elementos, Longitud);
            }
            else{
                Console.WriteLine("Introdusca una Longitud abajo o igual a 1000");
            }
        }
    public void DelElements2(int posicion,int[] elemts2){
                for(int i =posicion; i < Longitud; i++){
                    if(i+1 == Longitud){
                       Longitud = Longitud-1;
                       Array.Resize(ref Elementos, Longitud);
                       break; 
                    }
                    else{
                        int Aux = elemts2[i+1];
                        Elementos[i] = Aux; 
                    }
                    
                }
            }
    public void PonerElemento(int posicion, int element){
            if(Longitud > 0 && posicion <=Longitud ){
                Elementos[posicion-1] = element; 
            }
        }
    public int ObtenerEmento(int posicion){
            return Elementos[posicion-1];
        }
    public void SelectionSort(){
        if(Longitud > 1){
            for (int i = 0; i < Longitud - 1; i++) {
                int min= i;
                for (int j = i + 1; j < Longitud; j++) {
                    if (Elementos[j] < Elementos[min]) {
                        min = j;
                    }
                }
                int Aux2 = Elementos[i];
                Elementos[i] = Elementos[min];
                Elementos[min] = Aux2;         
            }
        }
    }
    public void InsertionSort(){
        if(Longitud > 1){
            for (int i = 1; i < Longitud; ++i) {
                int Aux3 = Elementos[i];
                int j = i - 1;
                while (j >= 0 && Elementos[j] > Aux3) {
                    Elementos[j + 1] = Elementos[j];
                    j = j - 1;
                }
                Elementos[j + 1] = Aux3;
            }
        }
    }
    public int[] ObtenerElemntos(){
        return Elementos;
    }
    public void InsetarElement0(int posicion, int elemt,int[] elemts){
        if(posicion  > Longitud ){
            Console.WriteLine("No se puede introducir el numeor a esa posicion");
        }
        else{
            int[] ChangeElements(int posicion2,int[] elemts2,int val){
                if(posicion2 == Longitud-1){
                    Elementos[posicion2] = val;
                    return Elementos;
                }
                else{
                    int Aux4 = Elementos[posicion2];
                    Elementos[posicion2] = val; 
                    return ChangeElements(posicion2+1,elemts2, Aux4);
                }
            }
            Longitud = Longitud+1;
            if(Longitud <= Max){
                Array.Resize(ref Elementos, Longitud);
                ChangeElements(posicion, elemts, elemt);
            }
            else{
                Longitud = Longitud-1;
                Console.WriteLine("Ha alcanzado la maxima longitud");
            }
        }
        
    }
    public void ElimElemento(int posicion, int elemt,int[] elemts){
        if(posicion  > Longitud ){
            Console.WriteLine("No se puede introducir el numeor a esa posicion");
        }
        else{
            int[] DelElements(int posicion2,int[] elemts2,int val){
                if(posicion2 == Longitud-1){
                    Elementos[posicion2] = Elementos[Longitud];
                    return Elementos;
                }
                else{
                    int Aux4 = Elementos[posicion2+1];
                    Elementos[posicion2] = val; 
                    return DelElements(posicion2+1,elemts2, Aux4);
                }
            }
            Longitud = Longitud-1;
            if(Longitud >= 1){
                int Aux5 = Elementos[posicion+1];
                Elementos[posicion] = Aux5;
                DelElements(posicion+1, elemts, elemt);
                Array.Resize(ref Elementos, Longitud);
            }
            else{
                Longitud = Longitud+1;
                Console.WriteLine("Ha alcanzado la minima longitud");
            }
        }
        
    }
    public bool Comparar(Vector vector1){
        if(Longitud == vector1.Longitud){
            int[] Elementos2 = vector1.ObtenerElemntos();
            for(int i =0; i < Longitud; i++){
                if(Elementos[i] != Elementos2[i]){
                    return false;
                }
            }
            return true;
        }
        else{
            return false;
        }
    }
    public void EliminarDuplicados(){
        for(int i =0; i<Longitud; i++){
            int contador =0;
            for(int j =i;j <Longitud;j++){
                if(Elementos[i] == Elementos[j]){
                    contador +=1;
                }
                if(Elementos[i] == Elementos[j] && contador >= 2){
                    int Aux6 = Elementos[j];
                    DelElements2(j, Elementos);

                }
            }
        }
    }
    public void Union(Vector vector1){
        int Longitud1 = Longitud+1;
        Longitud = Longitud + vector1.Longitud;
        Array.Resize(ref Elementos, Longitud);
        int[] Elements2 = vector1.ObtenerElemntos();
        for(int i = 0; i< vector1.Longitud;i++){
            PonerElemento(Longitud1+i, Elements2[i]);
        }
        PrintVector();
        EliminarDuplicados();
    }
    public bool Subconjunto(Vector vector1){
        if(Longitud == vector1.Longitud){
            int[] Elementos2 = vector1.ObtenerElemntos();
        int contador1 = 0;
        for(int i = 0; i<Longitud; i++){
            int contador2 = 0;
            for(int j =0; j < vector1.Longitud; j++){
                if(Elementos[i] == Elementos2[j] && contador2 == 0){
                    contador1 +=1;
                    contador1 +=1;
                }
            }
        }
        if(contador1 == vector1.Longitud){
            return true;
        }
        else{
            return false;
        }
        }
        else{
            return false;
        }
        
    }
    public void PrintVector(){
        String Aux1 = "";
        if(Longitud > 0){
            foreach( int val in Elementos){
                Aux1 += val;
                Aux1 += " ";
        }
        Console.WriteLine(Aux1);
        }
    }
    

        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZyLab_Codility
{
    class function2

    {

        static void Main(string[] args)
        {

                       int[,] arry = new int[7, 3] { 
                                        
                           { 5 , 4 ,4 }, { 4 , 3 ,4 }, { 3 ,2,4 }, { 2 ,2 ,2 } ,{ 3 ,3 ,4 }, {1 , 4 ,4 }, { 4,  1 ,1 }
                               };

                       Console.WriteLine(countries_count(ref arry).ToString());
            Console.ReadKey();
            
         
         }


       static void checkNeighbor( int[,] A,ref int[,] B, int i,int j, int N, int M)
        {
            if(B[i,j] == -1) return;
            B[i,j] = -1;
            if(i+1 < N)
            if(A[i + 1,j] == A[i,j]) checkNeighbor( A, ref B, i+1, j, N, M);
            if(i-1 >= 0)
            if(A[i - 1,j] == A[i,j]) checkNeighbor( A, ref B, i-1, j, N, M);
            if(j+1 < M)
           if(A[i,j + 1] == A[i,j]) checkNeighbor( A, ref B, i, j+1, N, M);
            if(j-1 >= 0)
            if(A[i,j - 1] == A[i,j]) checkNeighbor( A,ref B, i, j-1, N, M);
    }

   static int countries_count( ref int[,] A)
    {
        if (A.Length==0) return 0;
        int sum = 0;
        int N = 7;
        int M = 3; // N*M
        if (N == 0 || M == 0) return 0;
        int[,] B = A.Clone() as int[,]; 
        for (int i = 0; i < N; i++)
            for (int j = 0; j < M; j++)
            {
                if (B[i,j] >= 0)
                {
                    
                    checkNeighbor (A, ref B, i, j, N, M);
                    sum++;
                }
            }
        return sum;
    }


}
}

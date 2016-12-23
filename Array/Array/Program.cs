using System;

namespace DerivedFromArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 10, 30, 20, 7, 1 };
            Console.WriteLine("Type of array : {0}", array.GetType());
            Console.WriteLine("Base type of array : {0}", array.GetType().BaseType);
        }
    }
}

/*
 * 정적 메소드
 * Sort() : 배열을 정렬
 * BinarySearch<T>() : 이진 탐색을 수행
 * IndexOf() : 배열에서 찾고자 하는 특정 데이터의 인덱스를 반환
 * TrueForAll<T>() : 배열의 모든 요소가 지정한 조건에 부합하는지의 여부를 반환
 * FindIndex<T>() : 배열에서 지정한 조건에 부합하는 첫 번째 요소의 인덱스를 반환
 * Resize<T>() : 배열의 크기를 재조정
 * Clear() : 배열의 모든 요소를 초기화, 배열의 숫자 형식 기반이면 0으로, 논리 형식 기반이면 false로, 참조 형식 기반이면 null
 * ForEach<T>() : 배열의 모든 요소에 대해 동일한 작업을 수행
 * 
 * 인스턴스 메소드
 * GetLength() : 배열에서 지정한 차원의 길이를 반환
 * 
 * 프로퍼티
 * Length : 배열의 길이를 반환
 * Rank : 배열의 차원을 반환
 */
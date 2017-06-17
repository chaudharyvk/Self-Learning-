// array to sort
var array = [9, 2, 5, 6, 4, 3, 7, 10, 1, 8,5,5,5,5,533,335,545,444222,222,1];

// swap function helper
function swap(array, i, j) {
  var temp = array[i];
  array[i] = array[j];
  array[j] = temp;
}


function bubbleSortBasic(array) {
  for(var i = 0; i < array.length-1; i++)
  
  {
    for(var j = 0; j < array.length; j++) {
      if(array[j] > array[j+1]) {
        swap(array, j+1 , j);
      }
    }
  }
  return array;
}

console.log(bubbleSortBasic(array.slice())); 
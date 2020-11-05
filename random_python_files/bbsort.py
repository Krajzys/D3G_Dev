def bbsort(toSort: list, desc=False):
	"""
	Simple bubble sort implementation
	"""
	sortedList = toSort[:]
	isSorted = False
	while not isSorted:
		isSorted = True
		for i in range(len(sortedList) - 1):
			if (not desc) and (sortedList[i] > sortedList[i+1]):
				sortedList[i], sortedList[i+1] = sortedList[i+1], sortedList[i]
				isSorted = False
			elif desc and (sortedList[i] < sortedList[i+1]):
				sortedList[i], sortedList[i+1] = sortedList[i+1], sortedList[i]
				isSorted = False
	return sortedList
	
print(bbsort([1,9,2,3,7,5,4,11,9,56,3,54,3,54,3,56,13,23,34,54,-1]))
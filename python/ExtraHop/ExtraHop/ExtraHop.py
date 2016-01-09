import Dictionary
import Grid

def main():
	"""
		create word dictionary
		prep character grid
		find the longest word
		display word
	"""
	dictionary = prepDictionary()
	
	grid = prepGrid()

	word = grid.findLongestWord(dictionary)
	print "Longest word found is :" + word


def prepDictionary():
	"""preps dictionary from a file
	"""

	dictionary = Dictionary.Dictionary()
	input = open('t.txt', 'r')
	for line in input:
		dictionary.loadWords(line)
	input.close()
	return dictionary

def prepGrid():
	"""Preps the grid
	"""

	knightMoves = [(2,1),(1,2),(-1,2),(-2,1),(-2,-1),(-1,-2),(1,-2),(2,-1)]
	input = open("grid.txt", "r")
	rows = input.readlines()
	input.close()
	txtGrid = []
	for line in rows:
		txtGrid.append(line.split())
	return Grid.Grid(txtGrid, knightMoves)

if __name__ == "__main__":
	# execute only if run as a script
	main()

	
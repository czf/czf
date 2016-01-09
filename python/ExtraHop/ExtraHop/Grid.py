class Grid(object):
	"""A grid to find words		
	"""
	def __init__(self, grid, moves):
		self._grid = grid
		self._longestWord = None
		self._moves = moves
	def findLongestWord(self, dictionary):
		"""finds the longest word in the grid using the provided dictionary
		"""
		if (
				(not dictionary.hasWords()) or 
				len(self._grid) < 1 or
				len(self._grid[0]) < 1):
			return None

		self.__largestLength = dictionary.largestPossibleLength()
		for row in range(0,len(self._grid)):
			for col in range(0, len(self._grid[row])):
				newLongest = self._findLongestHelper((row, col), "", dictionary)		
				self._setLongestWord(newLongest)

				if self._isWordLongestPossibleLength():
					return self._longestWord

		return self._longestWord		

	def _findLongestHelper(self, cord, currentSubstring, dictionary):
		"""Recursive helper function to find the longest word
		"""
		currentSubstring += self._grid[cord[0]][cord[1]]
		if dictionary.isWord(currentSubstring) and (self._longestWord == None or len(currentSubstring) > len(self._longestWord)):
			self._longestWord = currentSubstring

		if self._isWordLongestPossibleLength():  #any other words would be shorter or the same length
			return self._longestWord
		
		if dictionary.isWordStart(currentSubstring):  #see if possible longer words
			self._checkValidMoves(cord, currentSubstring, dictionary)
		
		return self._longestWord


	def _checkValidMoves(self, cord, currentSubstring, dictionary):
		"""Recursively check only legal moves on the board.
		"""
		for move in self._moves:
			newRow = cord[0] + move[0]
			newCol = cord[1] + move[1]
			if self._isValidMove((newRow, newCol), cord):
				newGrid = Grid(self._grid, self._moves)
				newGrid.__largestLength = self.__largestLength
				word = newGrid._findLongestHelper((newRow, newCol), currentSubstring, dictionary)
				self._setLongestWord(word)
				if self._isWordLongestPossibleLength():
					return self._longestWord
	
	def _setLongestWord(self, word):
		""" set the grid longest word to word
		"""
		if (self._longestWord is None or
			( word is not None and len(self._longestWord) < len(word))):
			self._longestWord = word
	
	def _isWordLongestPossibleLength(self):
		""" determines if the grid's longest word is the max of word lengths in the dictionary
		"""
		return (self._longestWord is not None and len(self._longestWord) == self.__largestLength)

												
	def _isValidMove(self, move, cord):
		"""Determines if the movement is within the bounds of the grid
		"""
		return (
			move[0] > -1 and move[1] > -1 and
			move[0] < len(self._grid) and 
			move[1] < len(self._grid[cord[1]])
		)
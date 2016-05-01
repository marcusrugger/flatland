
BIN_FOLDER			= bin
INTERFACES_FOLDER	= interfaces
COMMON_FOLDER		= common
GDIPLUS_FOLDER		= gdiplus


all:	$(BIN_FOLDER)
	$(MAKE) -C $(INTERFACES_FOLDER)
	$(MAKE) -C $(COMMON_FOLDER)
	$(MAKE) -C $(GDIPLUS_FOLDER)


clean:
	$(MAKE) -C $(INTERFACES_FOLDER) clean
	$(MAKE) -C $(COMMON_FOLDER) clean
	$(MAKE) -C $(GDIPLUS_FOLDER) clean


$(BIN_FOLDER):
	mkdir $(BIN_FOLDER)

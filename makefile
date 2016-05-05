
BIN_FOLDER			= bin
INTERFACES_FOLDER	= interfaces
CORE_FOLDER			= core
GDIPLUS_FOLDER		= gdiplus
GDIPLUSAPP_FOLDER	= gdiplusapp
CAIRO_FOLDER		= cairo
CAIROAPP_FOLDER		= cairoapp


all:	$(BIN_FOLDER)
	$(MAKE) -C $(INTERFACES_FOLDER)
	$(MAKE) -C $(CORE_FOLDER)
	$(MAKE) -C $(GDIPLUS_FOLDER)
	$(MAKE) -C $(GDIPLUSAPP_FOLDER)
	$(MAKE) -C $(CAIRO_FOLDER)
	$(MAKE) -C $(CAIROAPP_FOLDER)


clean:
	$(MAKE) -C $(INTERFACES_FOLDER) clean
	$(MAKE) -C $(CORE_FOLDER) clean
	$(MAKE) -C $(GDIPLUS_FOLDER) clean
	$(MAKE) -C $(GDIPLUSAPP_FOLDER) clean
	$(MAKE) -C $(CAIRO_FOLDER) clean
	$(MAKE) -C $(CAIROAPP_FOLDER) clean


$(BIN_FOLDER):
	mkdir $(BIN_FOLDER)


rungdi:
	mono $(BIN_FOLDER)/gdiplusapp.exe


runcairo:
	mono $(BIN_FOLDER)/cairoapp.exe

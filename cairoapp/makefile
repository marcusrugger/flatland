
SOURCE = 	cairoapp.cs		\
			window.cs


ROOT_DIR	= ..
BIN_DIR		= $(ROOT_DIR)/bin
APP_NAME	= cairoapp.exe
TARGET		= $(BIN_DIR)/$(APP_NAME)

PACKAGES	= -pkg:gtk-sharp-3.0
LIBRARIES	= -r:$(BIN_DIR)/flatland.interfaces.dll -r:$(BIN_DIR)/flatland.common.dll -r:$(BIN_DIR)/flatland.cairo.dll

all:		$(TARGET)


clean:
	-rm $(TARGET)


run:		$(TARGET)
	mono $(TARGET)


$(TARGET):	$(SOURCE)
	mcs -out:$@ -target:exe $(PACKAGES) $(LIBRARIES) $^

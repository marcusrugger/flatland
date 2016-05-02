
SOURCE = 	context.cs


NUNIT_VERSION		=	nunit-3.2.1
NUNIT_PATH			=	/mnt/data/bin/$(NUNIT_VERSION)
NUNIT_FRAMEWORK		=	$(NUNIT_PATH)/bin/net-4.0/nunit.framework.dll
NUNIT_CONSOLE		=	$(NUNIT_PATH)/bin/nunit3-console.exe

ROOT_DIR	= ..
BIN_DIR		= $(ROOT_DIR)/bin
DLL_NAME	= flatland.cairo.dll
TARGET		= $(BIN_DIR)/$(DLL_NAME)

INTERFACES  = $(BIN_DIR)/flatland.interfaces.dll
COMMON  	= $(BIN_DIR)/flatland.common.dll
LIBRARIES	= -r:$(INTERFACES) -r:$(COMMON)
PACKAGES	= -pkg:gtk-sharp-3.0


all:		$(TARGET)


clean:
	-rm $(TARGET)
	-rm tests.dll
	-rm tests.mdb


runtests:	tests.dll
	mono $(NUNIT_CONSOLE) tests.dll -noresult


$(TARGET):	$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) $(LIBRARIES) $^


tests.dll:	turtle.test.cs				\
			$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) $(LIBRARIES) -r:$(NUNIT_FRAMEWORK) $^


SOURCE = 	context.cs			\
			canvas.cs			\
			graphics.cs			\
			turtle.cs			\
			wireframe.cs


NUNIT_VERSION		=	nunit-3.2.1
NUNIT_PATH			=	/mnt/data/bin/$(NUNIT_VERSION)
NUNIT_FRAMEWORK		=	$(NUNIT_PATH)/bin/net-4.0/nunit.framework.dll
NUNIT_CONSOLE		=	$(NUNIT_PATH)/bin/nunit3-console.exe

ROOT_DIR	= ..
BIN_DIR		= $(ROOT_DIR)/bin
DLL_NAME	= flatland.common.dll
TARGET		= $(BIN_DIR)/$(DLL_NAME)

INTERFACES  = $(BIN_DIR)/flatland.interfaces.dll
PACKAGES	= -pkg:dotnet


all:		$(TARGET)


clean:
	-rm $(TARGET)
	-rm tests.dll
	-rm tests.mdb


runtests:	tests.dll
	mono $(NUNIT_CONSOLE) tests.dll -noresult


$(TARGET):	$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) -r:$(INTERFACES) $^


tests.dll:	turtle.test.cs				\
			$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) -r:$(INTERFACES) -r:$(NUNIT_FRAMEWORK) $^

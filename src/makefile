
SOURCE = 	algorithms.cs					\
			constants.cs					\
			color.cs						\
			point.cs						\
			cartesian.cs					\
			polar.cs						\
			drawline.cs


NUNIT_VERSION		=	nunit-3.2.1
NUNIT_PATH			=	/mnt/data/bin/$(NUNIT_VERSION)
NUNIT_FRAMEWORK		=	$(NUNIT_PATH)/bin/net-4.0/nunit.framework.dll
NUNIT_CONSOLE		=	$(NUNIT_PATH)/bin/nunit3-console.exe

ROOT_DIR	= ..
BIN_DIR		= $(ROOT_DIR)/bin
DLL_NAME	= flatland.dll
TARGET		= $(BIN_DIR)/$(DLL_NAME)

PACKAGES	= -pkg:dotnet


all:		$(TARGET)	\
			runtests


clean:
	-rm $(TARGET)
	-rm tests.dll
	-rm tests.mdb


runtests:	tests.dll
	mono $(NUNIT_CONSOLE) tests.dll -noresult


$(TARGET):	$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) $^


tests.dll:	polar.test.cs				\
			cartesian.test.cs			\
			algorithms.test.cs			\
			point.test.cs				\
			color.test.cs				\
			$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) -r:$(NUNIT_FRAMEWORK) $^

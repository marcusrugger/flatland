
SOURCE = 	algorithms.cs					\
			constants.cs					\
			color.cs						\
			color.colorb.cs					\
			color.colorf.cs					\
			color.colord.cs					\
			coordinate.cs					\
			point.cs						\
			cartesian.cs					\
			polar.cs						\
			turtle.cs						\
			canvas.cs						\
			wireframe.cs					\
			matrix33.cs						\
			transformer.cs


NUNIT_VERSION		=	nunit-3.2.1
NUNIT_PATH			=	/mnt/data/bin/$(NUNIT_VERSION)
NUNIT_FRAMEWORK		=	$(NUNIT_PATH)/bin/net-4.0/nunit.framework.dll
NUNIT_CONSOLE		=	$(NUNIT_PATH)/bin/nunit3-console.exe

ROOT_DIR	= ..
BIN_DIR		= $(ROOT_DIR)/bin
DLL_NAME	= flatland.interfaces.dll
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
			color.colorb.test.cs		\
			color.colorf.test.cs		\
			color.colord.test.cs		\
			matrix33.test.cs			\
			$(SOURCE)
	mcs -out:$@ -target:library $(PACKAGES) -r:$(NUNIT_FRAMEWORK) $^

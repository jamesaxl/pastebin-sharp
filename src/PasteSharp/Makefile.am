
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;WEB_CLIENT"
ASSEMBLY = bin/Debug/PasteSharp.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

PASTESHARP_DLL_MDB_SOURCE=bin/Debug/PasteSharp.dll.mdb
PASTESHARP_DLL_MDB=$(BUILD_DIR)/PasteSharp.dll.mdb
SOUP_SHARP_DLL_SOURCE=../../lib/soup-sharp.dll

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/PasteSharp.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

PASTESHARP_DLL_MDB=
SOUP_SHARP_DLL_SOURCE=../../lib/soup-sharp.dll

endif

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;WEB_CLIENT"
ASSEMBLY = bin/Debug/PasteSharp.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

PASTESHARP_DLL_MDB_SOURCE=bin/Debug/PasteSharp.dll.mdb
PASTESHARP_DLL_MDB=$(BUILD_DIR)/PasteSharp.dll.mdb
SOUP_SHARP_DLL_SOURCE=../../lib/soup-sharp.dll

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/PasteSharp.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

PASTESHARP_DLL_MDB=
SOUP_SHARP_DLL_SOURCE=../../lib/soup-sharp.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PASTESHARP_DLL_MDB) \
	$(SOUP_SHARP_DLL)  

LINUX_PKGCONFIG = \
	$(PASTESHARP_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	Properties/AssemblyInfo.cs \
	FpasteScsys.cs \
	Bpaste.cs \
	DebianPasteBin.cs \
	Fpaste.cs \
	Bernami.cs \
	Bridge.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	pastesharp.pc.in 

REFERENCES =  \
	System \
	System.Net \
	$(GLIB_SHARP_30_LIBS)

DLL_REFERENCES =  \
	../../lib/soup-sharp.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

SOUP_SHARP_DLL = $(BUILD_DIR)/soup-sharp.dll
PASTESHARP_PC = $(BUILD_DIR)/pastesharp.pc

$(eval $(call emit-deploy-target,SOUP_SHARP_DLL))
$(eval $(call emit-deploy-wrapper,PASTESHARP_PC,pastesharp.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)

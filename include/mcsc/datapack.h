#include <mcsc/datapack/meta.h>
#include <mcsc/datapack/packformat.h>
#include <mcsc/command/proxybuilder.h>

#include <string>
#include <string_view>
#include <filesystem>
#include <glog/logging.h>

namespace mcsc {

class DatapackBuilder {
public:
	DatapackBuilder(const std::string& pack_name, const std::string& req_ver = "");
	~DatapackBuilder();

public:
	int					   getPackFormat() const;
	const std::string& getPackName() const;
	const std::string& getDescription() const;

	void setDescription(const std::string& desc);

protected:
	void startLogger(const std::string& id);
	void shutdownLogger();

private:
	int			format_;
	std::string pack_name_;
	std::string description_;
};

};	 // namespace mcsc
#include <mcsc/datapack/packformat.h>
#include <mcsc/datapack/itemtree.h>
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
	int				   getPackFormat() const;
	const std::string& getPackName() const;
	const std::string& getDescription() const;

	void setDescription(const std::string& desc);

	template <datapack::Namespace ns> bool begin() {
		if (current_ns_ != datapack::Namespace::NS_Unused) return false;
		current_ns_ = ns;
		return true;
	}
	void end();

protected:
	void startLogger(const std::string& id);
	void shutdownLogger();

private:
	int			format_;
	std::string pack_name_;
	std::string description_;

	datapack::Namespace current_ns_;
};

template <> bool DatapackBuilder::begin<datapack::Namespace::NS_Func>();

};	 // namespace mcsc

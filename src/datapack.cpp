#include <mcsc/datapack.h>

#include <time.h>
#include <algorithm>
#include <regex>
#include <sstream>

namespace mcsc {

using datapack::Namespace;

DatapackBuilder::DatapackBuilder(const std::string& pack_name, const std::string& req_ver)
	: pack_name_(pack_name)
	, current_ns_(Namespace::NS_Unused) {
	startLogger(pack_name);

	enum class cmpmode { EQ, GT, GE } mode = cmpmode::EQ;
	Version			version;
	constexpr auto& verftable = datapack::VerFormatTable;

	std::smatch result;
	std::regex	pattern(R"(^(>|=|>=)?(\d+)(\.(\d+)(\.(\d+))?)?$)");
	std::regex_match(req_ver, result, pattern);

	datapack::detail::VerFormatItem item = verftable[0];
	if (!result.empty()) {
		version.major = std::stoi(result[2]);
		version.minor = result[4].length() == 0 ? 0 : std::stoi(result[4]);
		version.patch = result[6].length() == 0 ? 0 : std::stoi(result[6]);
		mode		  = result[1].length() == 2		? cmpmode::GE
						: result[1].str()[0] == '>' ? cmpmode::GT
													: cmpmode::EQ;

		for (const auto& e : verftable) {
			if (mode == cmpmode::EQ) {
				if (e.lobound <= version && version <= e.hibound) {
					item = e;
					break;
				} else if (e.hibound < version) {
					item = e;
				}
			}
			if (mode == cmpmode::GT) {
				if (e.lobound > version) {
					item = e;
					break;
				} else if (e.hibound > version) {
					item = e;
				}
			}
			if (mode == cmpmode::GE) {
				if (e.lobound >= version) {
					item = e;
					break;
				} else if (e.hibound >= version) {
					item = e;
				}
			}
		}
	} else {
		LOG(WARNING) << "mcsc::DatapackBuilder: ill-formed version requirement `" << req_ver << "'";
	}
	format_ = item.format;

	std::stringstream ss;
	ss << "Minecraft datapack developed for " << (int)item.lobound.major << "."
	   << (int)item.lobound.minor << "." << (int)item.lobound.patch << "-"
	   << (int)item.hibound.major << "." << (int)item.hibound.minor << "."
	   << (int)item.hibound.patch;
	description_ = ss.str();
}

DatapackBuilder::~DatapackBuilder() {
	shutdownLogger();
}

int DatapackBuilder::getPackFormat() const {
	return format_;
}

const std::string& DatapackBuilder::getPackName() const {
	return pack_name_;
}

const std::string& DatapackBuilder::getDescription() const {
	return description_;
}

void DatapackBuilder::setDescription(const std::string& desc) {
	description_ = desc;
}

void DatapackBuilder::startLogger(const std::string& id) {
	std::string packid(id.size() + 1, '_');
	std::transform(
		id.begin(), id.end(), packid.begin(), [](char ch) { return ch == ' ' ? '_' : ch; });
	packid = "DatapackBuider-" + packid;
	google::InitGoogleLogging(id.c_str());
	google::SetLogDestination(google::GLOG_INFO, packid.c_str());
	google::SetLogFilenameExtension(".mcsc-log");
}

void DatapackBuilder::shutdownLogger() {
	google::ShutdownGoogleLogging();
}

void DatapackBuilder::end() {
	LOG(WARNING) << "mcsc::DatapackBuilder: end() called without begin()";
	// TODO
	while (!cmd_queue_.empty()) {
		auto& cmd	  = cmd_queue_.front();
		auto  discard = cmd->apply();
		delete cmd;
		cmd_queue_.pop();
	}
	current_ns_ = datapack::Namespace::NS_Unused;
}

void DatapackBuilder::commit(command::Command* cmd) {
	// TODO
	cmd_queue_.push(cmd);
}

template <> bool DatapackBuilder::begin<datapack::Namespace::NS_Func>() {
	// TODO
	if (current_ns_ != datapack::Namespace::NS_Unused) return false;
	current_ns_ = datapack::Namespace::NS_Func;
	return true;
}

void DatapackBuilder::save(const std::string& loc) const {
	save_as(getPackName(), loc);
}

void DatapackBuilder::save_as(const std::string& name, const std::string& loc) const {
	// TODO
}

};	 // namespace mcsc